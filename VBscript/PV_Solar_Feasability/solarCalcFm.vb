Imports ESRI.ArcGIS.ArcMapUI
Imports ESRI.ArcGIS.Carto
Imports ESRI.ArcGIS.Geometry
Imports ESRI.ArcGIS.esriSystem
Imports ESRI.ArcGIS.Geodatabase
Imports ESRI.ArcGIS.DataSourcesGDB
Imports ESRI.ArcGIS.Display
Imports ESRI.ArcGIS.DataSourcesFile
Imports ESRI.ArcGIS.Geoprocessing
Imports globalVariables

Public Class MainFm
    Private Sub ExitBt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitBt.Click
        Me.Close()
    End Sub


    Private Sub selectBt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles selectBt.Click
        Dim payback As Integer = CInt(paybackTb.Text)
        Dim avgElecCost As Double = CDbl(elecCostTb.Text)
        'Dim avgInstCosts As Double = CDbl(avgInstCostsTb.Text)
        'Dim panelOutput As Double = CDbl(panelOutputTb.Text)
        'Dim panelSize As Double = CDbl(panelSizeTb.Text)
        'Dim fedTaxCredit as Double = CDbl(fedTaxCreditTb.Text) / 100
        'Dim stateTaxCredit as Double = CDbl(stateTaxCreditTb.Text) / 100
        Dim panelCost As Double = CDbl(panelCostTb.Text)
        Dim systemEff As Double = CDbl(systemEffTb.Text) / 100
        Dim panelEff As Double = CDbl(panelEffTb.Text) / 100

        'Dim panelCost As Double = (avgInstCosts / panelOutput / panelSize) * fedTaxCredit * stateTaxCredit
        Dim minValue As Double = panelCost / payback / avgElecCost / systemEff / panelEff / 365

        Dim pMxDocument As IMxDocument = My.ArcMap.Application.Document
        Dim pMap As IMap = pMxDocument.FocusMap
        Dim pPointLayer As IFeatureLayer = pMap.Layer(0)
        Dim pointSelection As IFeatureSelection = CType(pPointLayer, IFeatureSelection)
        Dim pFeatureClass As IFeatureClass = pPointLayer.FeatureClass
        Dim strQuery As String = "kwh_m2_day > " & CStr(minValue)
        Dim selectionSet As ISelectionSet

        MsgBox(strQuery)

        Dim pFilter As IQueryFilter = New QueryFilter

        pFilter.WhereClause = strQuery
        pointSelection.SelectFeatures(pFilter, esriSelectionResultEnum.esriSelectionResultNew, False)


        selectionSet = pFeatureClass.Select(pFilter, esriSelectionType.esriSelectionTypeHybrid, esriSelectionOption.esriSelectionOptionNormal, Nothing)

        MsgBox("The number of points suitable for solar panel instllation on UNC's Campus with these parameters is: " & selectionSet.Count)

        Dim pActiveView As IActiveView = pMxDocument.ActiveView
        ' Invalidate only the selection cache. Flag the original selection
        pActiveView.PartialRefresh(ESRI.ArcGIS.Carto.esriViewDrawPhase.esriViewGeoSelection, Nothing, Nothing)

        ZoomToSelFeatures(pPointLayer, pMxDocument)
    End Sub

    Public Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxBuildingSel.SelectedIndexChanged
        'Initialize the combobox with cursor

        Dim payback As Integer = CInt(paybackTb.Text)
        Dim avgElecCost As Double = CDbl(elecCostTb.Text)
        Dim panelCost As Double = CDbl(panelCostTb.Text)
        Dim systemEff As Double = CDbl(systemEffTb.Text) / 100
        Dim panelEff As Double = CDbl(panelEffTb.Text) / 100

        Dim minValue As Double = panelCost / payback / avgElecCost / systemEff / panelEff / 365

        MsgBox("You have selected " & cbxBuildingSel.Text)

        'only select points with the user-defined building name'
        Dim pMxDocument As IMxDocument = My.ArcMap.Application.Document
        Dim pMap As IMap = pMxDocument.FocusMap
        Dim pPointLayer As IFeatureLayer = pMap.Layer(0)
        Dim strQuery As String = "BUILDINGNA = '" & cbxBuildingSel.Text & "'"
        Dim queryFilter As IQueryFilter = New QueryFilter
        queryFilter.WhereClause = strQuery

        Dim pActiveView As IActiveView = pMxDocument.ActiveView
        ' Invalidate only the selection cache. Flag the original selection
        pActiveView.PartialRefresh(ESRI.ArcGIS.Carto.esriViewDrawPhase.esriViewGeoSelection, Nothing, Nothing)

        Dim pPointLayerDef As IFeatureLayerDefinition = pMap.Layer(0)

        If cbxBuildingSel.Text = "<select building>" Then
            pPointLayerDef.DefinitionExpression = ""
            pActiveView.Extent = pPointLayer.AreaOfInterest
        Else
            'pPointLayerDef.DefinitionExpression = strQuery
            Dim pBuildingSelClass As IFeatureClass = pPointLayer.FeatureClass

            Dim pFilter As IQueryFilter = New QueryFilter
            pFilter.WhereClause = strQuery

            Dim pFCursor As IFeatureCursor = pBuildingSelClass.Search(pFilter, True)
            Dim pFeature As IFeature = pFCursor.NextFeature

            Dim buildingCursor As ICursor = pFCursor
            Dim buildingRow As IRow = buildingCursor.NextRow()
            Dim pBuildingFields As IFields = pBuildingSelClass.Fields

            'Find the total building area'
            Dim buildingAreaValue As Integer = pBuildingFields.FindField("SHAPE_AREA")
            If buildingAreaValue = -1 Then
                MsgBox("Building Area field has not been found.")
            End If
            totalBuildArea = buildingRow.Value(buildingAreaValue)

            'Find the total solar potential of the building using the kwh_m2_day field'
            Dim buildingKwhValue As Integer = pBuildingFields.FindField("kwh_m2_day")
            Dim feasibleKwh As Integer
            If buildingKwhValue = -1 Then
                MsgBox("kwh_m2_day field has not been found.")
            End If
            totalPotential = 0
            Dim counter As Integer = 0
            While Not buildingRow Is Nothing
                If buildingRow.Value(buildingKwhValue) >= minValue Then
                    feasibleKwh = buildingRow.Value(buildingKwhValue)
                    totalPotential = totalPotential + feasibleKwh
                    counter += 1
                End If
                buildingRow = buildingCursor.NextRow()
            End While
            totalPotential = totalPotential * 2.4384
            totalSavings = totalPotential * panelEff * systemEff * avgElecCost * 365

            'find the total area usable for solar'
            totalSolarArea = counter * 64
            totalPanels = counter * 3

            If counter > 0 Then
                MsgBox("The total area of the building is " & totalBuildArea & " square feet" & Environment.NewLine & Environment.NewLine & "The potential usabale area for solar on the building is " & totalSolarArea & " square feet." & Environment.NewLine & Environment.NewLine & "The total solar potential of building is " & totalPotential & " kWh/m^2/day" & Environment.NewLine & Environment.NewLine & "The total number of panels you could install on the roof is " & totalPanels & Environment.NewLine & Environment.NewLine & "The total annual electricity cost savings for the building if all feasible panels were installed is $" & totalSavings)
            Else
                MsgBox(cbxBuildingSel.Text & " has no feasible solar installation potential at these parameter values")
            End If
        End If

        pActiveView.Refresh()
    End Sub

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        Dim pMxDoc As IMxDocument = My.ArcMap.Application.Document
        Dim pMap As IMap
        pMap = pMxDoc.FocusMap

        Dim pBuildingLayer As IFeatureLayer
        pBuildingLayer = pMap.Layer(1)

        Dim pBuildingClass As IFeatureClass
        pBuildingClass = pBuildingLayer.FeatureClass

        Dim pFCursor As IFeatureCursor
        pFCursor = pBuildingClass.Search(Nothing, False)

        Dim pFeature As IFeature
        pFeature = pFCursor.NextFeature

        Dim pFields As IFields
        pFields = pBuildingClass.Fields

        Dim buildingIntPosValue As Integer
        buildingIntPosValue = pFields.FindField("BUILDINGNA")

        If buildingIntPosValue <> -1 Then
            Do Until pFeature Is Nothing
                cbxBuildingSel.Items.Add(pFeature.Value(buildingIntPosValue))
                pFeature = pFCursor.NextFeature
            Loop
            cbxBuildingSel.Sorted = True
            cbxBuildingSel.Refresh()

        Else
            MsgBox("No building name field was found. Cannot initiate the combobox.")
        End If

    End Sub

    Private Sub zoomBt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles zoomBt.Click

        Dim pMxDocument As IMxDocument = My.ArcMap.Application.Document
        Dim pMap As IMap = pMxDocument.FocusMap
        Dim pBuildLayer As IFeatureLayer = pMap.Layer(1)
        Dim buildSelection As IFeatureSelection = CType(pBuildLayer, IFeatureSelection)
        Dim pFeatureClass As IFeatureClass = pBuildLayer.FeatureClass
        Dim strQuery As String = "BUILDINGNA = '" & cbxBuildingSel.Text & "'"
        Dim selectionSet As ISelectionSet
        MsgBox(strQuery)

        Dim pFilter As IQueryFilter = New QueryFilter

        pFilter.WhereClause = strQuery
        buildSelection.SelectFeatures(pFilter, esriSelectionResultEnum.esriSelectionResultNew, True)

        MsgBox("Building Selected")

        SelectionSet = pFeatureClass.Select(pFilter, esriSelectionType.esriSelectionTypeHybrid, esriSelectionOption.esriSelectionOptionNormal, Nothing)

        Dim pActiveView As IActiveView = pMxDocument.ActiveView
        ' Invalidate only the selection cache. Flag the original selection
        pActiveView.PartialRefresh(ESRI.ArcGIS.Carto.esriViewDrawPhase.esriViewGeoSelection, Nothing, Nothing)

        ZoomToSelFeatures(pBuildLayer, pMxDocument)

    End Sub
    Public Sub ZoomToSelFeatures(ByVal pLayer As IFeatureLayer, ByVal pDoc As IMxDocument)

        Dim pFSel As IFeatureSelection
        pFSel = pLayer

        'Get the selected features

        Dim pSelSet As ISelectionSet
        pSelSet = pFSel.SelectionSet

        Dim pEnumGeom As IEnumGeometry
        Dim pEnumGeomBind As IEnumGeometryBind

        pEnumGeom = New EnumFeatureGeometry
        pEnumGeomBind = pEnumGeom
        pEnumGeomBind.BindGeometrySource(Nothing, pSelSet)

        Dim pGeomFactory As IGeometryFactory
        pGeomFactory = New GeometryEnvironment

        Dim pGeom As IGeometry
        pGeom = pGeomFactory.CreateGeometryFromEnumerator(pEnumGeom)

        pDoc.ActiveView.Extent = pGeom.Envelope
        pDoc.ActiveView.Refresh()
    End Sub

    Private Sub panelCostTb_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles panelCostTb.TextChanged

    End Sub
End Class