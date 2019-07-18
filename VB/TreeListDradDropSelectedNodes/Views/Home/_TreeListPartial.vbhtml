@ModelType IEnumerable(Of TreeListDradDropSelectedNodes.Data)
@Code
    Dim treeList = Html.DevExpress().TreeList(Of TreeListDradDropSelectedNodes.Data)(Sub(settings)
                                                                                         settings.Name = "TreeList1"
                                                                                         settings.Width = Unit.Pixel(200)

                                                                                         settings.CallbackRouteValues = New With {Key .Controller = "Home", Key .Action = "TreeListPartial"}
                                                                                         settings.SettingsEditing.NodeDragDropRouteValues = New With {Key .Controller = "Home", Key .Action = "TreeListDragDropAction"}

                                                                                         settings.KeyField(Function(m) m.ID)
                                                                                         settings.ParentField(Function(m) m.ParentID)

                                                                                         settings.Columns.Add(Function(m) m.Title)

                                                                                         settings.SettingsSelection.Enabled = True
                                                                                         settings.SettingsBehavior.AutoExpandAllNodes = True
                                                                                         settings.Settings.ShowColumnHeaders = False

                                                                                         settings.HtmlDataCellPrepared = Sub(sender, e)
                                                                                                                             e.Cell.CssClass = "customClass"
                                                                                                                         End Sub
                                                                                         settings.BeforeGetCallbackResult = Sub(sender, e)
                                                                                                                                TryCast(sender, MVCxTreeList).ExpandAll()
                                                                                                                            End Sub
                                                                                         settings.ClientSideEvents.StartDragNode = "onStartDragNode"
                                                                                         settings.ClientSideEvents.EndDragNode = "onEndDragNode"
                                                                                         settings.ClientSideEvents.BeginCallback = "onBeginCallback"
                                                                                     End Sub)
End Code
@treeList.Bind(Model).GetHtml()