import arcpy
from arcpy import env
from arcpy.sa import *


class Toolbox(object):
    def __init__(self):
        """Define the toolbox (the name of the toolbox is the name of the
        .pyt file)."""
        self.label = "Toolbox"
        self.alias = ""

        # List of tool classes associated with this toolbox
        self.tools = [LiDARsolar]
        return


class LiDARsolar(object):
    def __init__(self):
        """Define the tool (tool name is the name of the class)."""
        self.label = "LiDARsolar"
        self.description = "Process and clip LAS files to building shapefiles for solar suitability analysis"
        self.canRunInBackground = False

    def getParameterInfo(self):
        """Define parameter definitions"""
        param0 = arcpy.Parameter(displayName="Choose a workspace for your project", name="workspace", datatype="DEWorkspace", parameterType="Required",direction="Input")
        param1 = arcpy.Parameter(displayName="Select your bulding footprint shapefile", name="building_shp", datatype="DEFeatureClass", parameterType="Required", direction="Input")
        param2 = arcpy.Parameter(displayName="Select a LAS file", name="lasFile1", datatype="DEFile", parameterType="Required", direction="Input")
        param3 = arcpy.Parameter(displayName="Select another LAS file", name="lasFile2", datatype="DEFile", parameterType="Optional", direction="Input")        
        param4 = arcpy.Parameter(displayName="Select another LAS file", name="lasFile3", datatype="DEFile", parameterType="Optional", direction="Input")        
        param5 = arcpy.Parameter(displayName="Select another LAS file", name="lasFile4", datatype="DEFile", parameterType="Optional", direction="Input")
        param6 = arcpy.Parameter(displayName="Select the DEM file for your area", name="dem", datatype="DERasterDataset", parameterType="Required", direction="Input")
        params = [param0, param1,param2,param3,param4,param5, param6]
        return params

    def isLicensed(self):
        """Set whether tool is licensed to execute."""
        return True

    def updateParameters(self, parameters):
        """Modify the values and properties of parameters before internal
        validation is performed.  This method is called whenever a parameter
        has been changed."""
        return

    def updateMessages(self, parameters):
        """Modify the messages created by internal validation for each tool
        parameter.  This method is called after internal validation."""
        return

    def execute(self, parameters, messages):
        """The source code of the tool."""
	arcpy.env.workspace = str(parameters[6].value)
        arcpy.env.overwriteOutput = True
         
        arcpy.AddMessage("Processing: setting variables")

        # User input:
        arcpy.env.workspace = str(parameters[0].value)
        bldg_shp = str(parameters[1].value)
        las_1 = str(parameters[2].value)
        las_2 = str(parameters[3].value)
        las_3 = str(parameters[4].value)
        las_4 = str(parameters[5].value)
        dem = str(parameters[7].value)

        # Local variables:
        las_input = [las_1]
        if parameters[3].value != None:
            las_input.append(las_2)
        if parameters[4].value != None:
            las_input.append(las_3)
        if parameters[5].value != None:
            las_input.append(las_4)
        ptFileInfo = "ptFileInfo"
        multipt_all_shp = "multipt_all.shp"
        las_raster = "las_raster"
        dsm = "dsm"
        solar = "solar"
        Output_direct_radiation_raster = ""
        Output_diffuse_radiation_raster = ""
        Output_direct_duration_raster = ""
        dsm_clip = "dsm_clip"
        solar_pt_shp = "solar_pt.shp"
        bldg_pt_join_shp = "bldg_pt_join.shp"

        arcpy.AddMessage("Success! Variables set")

        arcpy.AddMessage("Processing: finding average pt spacing")
        # Find Average Point Spacing
        #arcpy.PointFileInformation_3d(las_input, ptFileInfo, "LAS")
        # insert cursor into "ptFileInfo", read the PtSpacing values, average the values
        rows = arcpy.SearchCursor(ptFileInfo)
        ptTotal = 0
        counter = 0
        for row in rows:
            pt_spacing = row.getValue("Pt_Spacing")
            ptTotal = ptTotal + pt_spacing
            counter = counter + 1
        avgPt = ptTotal/counter
        arcpy.AddMessage("Success! Average point spacing:")
	arcpy.AddMessage(avgPt)

        arcpy.AddMessage("Processing: LAS to Multipoint")
        # Process: LAS to Multipoint
        arcpy.LASToMultipoint_3d(las_input, multipt_all_shp , avgPt, "", "ANY_RETURNS", "", "PROJCS['NAD_1983_2011_StatePlane_North_Carolina_FIPS_3200',GEOGCS['GCS_NAD_1983_2011',DATUM['D_NAD_1983_2011',SPHEROID['GRS_1980',6378137.0,298.257222101]],PRIMEM['Greenwich',0.0],UNIT['Degree',0.0174532925199433]],PROJECTION['Lambert_Conformal_Conic'],PARAMETER['False_Easting',609601.2192024384],PARAMETER['False_Northing',0.0],PARAMETER['Central_Meridian',-79.0],PARAMETER['Standard_Parallel_1',34.33333333333334],PARAMETER['Standard_Parallel_2',36.16666666666666],PARAMETER['Latitude_Of_Origin',33.75],UNIT['Meter',1.0]]", "", "1", "NO_RECURSION")
        arcpy.AddMessage("Success! Multipoint file created")

        arcpy.AddMessage("Processing: Converting multipoint to raster")
        # Process: Point to Raster
        arcpy.PointToRaster_conversion(multipt_all_shp, "Shape.Z", las_raster, "MAXIMUM", "NONE", "2.43")
        arcpy.AddMessage("Success! Raster created")

        arcpy.AddMessage("Processing: Subracting DEM data from raster")
        # Process: Raster Calculator
        rasterCalc = Minus(las_raster, dem)
        rasterCalc.save("dsm")
        arcpy.AddMessage("Success! DSM file created")

        arcpy.AddMessage("Processing: Area solar radiation calculator")
        # Process: Area Solar Radiation
        arcpy.gp.AreaSolarRadiation_sa(dsm, solar, "39", "200", "WholeYear   2014", "14", "0.5", "INTERVAL", "1", "FROM_DEM", "32", "8", "8", "UNIFORM_SKY", "0.3", "0.5", Output_direct_radiation_raster, Output_diffuse_radiation_raster, Output_direct_duration_raster)
        arcpy.AddMessage("Success! Solar calculator complete")

        arcpy.AddMessage("Processing: Extracting solar analysis buildig shapefile geometry")
        # Process: Extract by Mask
        arcpy.gp.ExtractByMask_sa(solar, bldg_shp, dsm_clip)
        arcpy.AddMessage("Success! Data extracted by buildig shapefile geometry")

        arcpy.AddMessage("Processing: Converting raster to point")
        # Process: Raster to Point
        arcpy.RasterToPoint_conversion(dsm_clip, solar_pt_shp, "VALUE")
        arcpy.AddMessage("Success! Solar point file created")

        arcpy.AddMessage("Processing: Joining solar point file to building geometry")
        # Process: Spatial Join
        arcpy.SpatialJoin_analysis(solar_pt_shp, bldg_shp, bldg_pt_join_shp, "JOIN_ONE_TO_MANY", "KEEP_ALL")
        arcpy.AddMessage("Success! Spatial join complete")


