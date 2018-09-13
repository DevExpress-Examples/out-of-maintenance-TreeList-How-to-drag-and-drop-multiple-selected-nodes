Imports DevExpress.Web.Mvc
Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Function Index() As ActionResult
        Return View()
    End Function

    <ValidateInput(False)>
    Public Function TreeListPartial() As ActionResult
        Return PartialView("_TreeListPartial", DataHelper.GetData())
    End Function

    <HttpPost, ValidateInput(False)>
    Public Function TreeListDragDropAction(ByVal id As Integer, ByVal nodeKeys As Integer(), ByVal parentID As Integer) As ActionResult
        If nodeKeys Is Nothing Then
            DataHelper.MoveNode(id, parentID)
        Else
            DataHelper.MoveNodes(nodeKeys, parentID)
        End If

        Return PartialView("_TreeListPartial", DataHelper.GetData())
    End Function
End Class