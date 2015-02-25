Imports ESRI.ArcGIS.ArcMapUI
Imports ESRI.ArcGIS.Carto
Imports ESRI.ArcGIS.Geometry
Imports ESRI.ArcGIS.esriSystem
Imports ESRI.ArcGIS.Geodatabase
Imports ESRI.ArcGIS.DataSourcesGDB
Imports ESRI.ArcGIS.Display
Imports ESRI.ArcGIS.DataSourcesFile
Imports ESRI.ArcGIS.Geoprocessing

Public Class MainBt
    Inherits ESRI.ArcGIS.Desktop.AddIns.Button
    Dim totalBuildArea As Integer
    Dim totalSolarArea As Integer
    Dim totalPanels As Integer
    Dim totalPotential As Integer
    Dim totalSavings As Integer

    Protected Overrides Sub OnClick()

        My.ArcMap.Application.CurrentTool = Nothing
        Try
            AddShapeFile("uncBuild_ref", "T:\students\tchandle\Project_Organized\UNC_BuildingFootprint")
            AddShapeFile("build_point_spatial", "T:\students\tchandle\Project_Organized\Results")

            Dim f1 As New MainFm
            f1.Show()

        Catch ex As Exception
            MsgBox(ex.InnerException)

        End Try
    End Sub
    Private Sub AddShapeFile(ByVal shpFileName As String, ByVal dirPath As String)
        Try
            Dim pWorkspaceFactory As IWorkspaceFactory
            Dim pFeatureWorkspace As IFeatureWorkspace
            Dim pFeatureLayer As IFeatureLayer
            Dim pMxDocument As IMxDocument = My.ArcMap.Application.Document

            Dim pMap As IMap
            'Create a new ShapefileWorkspaceFactory object and open a shapefile folder
            pWorkspaceFactory = New ShapefileWorkspaceFactory
            pFeatureWorkspace = pWorkspaceFactory.OpenFromFile(dirPath, 0)
            'Create a new FeatureLayer and assign a shapefile to it
            pFeatureLayer = New FeatureLayer
            pFeatureLayer.FeatureClass = pFeatureWorkspace.OpenFeatureClass(shpFileName)
            pFeatureLayer.Name = pFeatureLayer.FeatureClass.AliasName
            pMap = pMxDocument.FocusMap
            pMap.AddLayer(pFeatureLayer)

            pMxDocument.ActiveView.Refresh()
            pMxDocument.UpdateContents()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Protected Overrides Sub OnUpdate()
        Enabled = My.ArcMap.Application IsNot Nothing
    End Sub
End Class
