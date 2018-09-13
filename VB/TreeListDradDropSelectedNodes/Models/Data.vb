Public Class Data
    Public Property ID As Integer
    Public Property ParentID As Integer
    Public Property Title As String
End Class

Module DataHelper
    Function GetData() As List(Of Data)
        Dim data As List(Of Data) = TryCast(HttpContext.Current.Session("Data"), List(Of Data))

        If data Is Nothing Then
            data = New List(Of Data)()
            data.Add(New Data With {
                .ID = 1,
                .ParentID = 0,
                .Title = "Root"
            })
            data.Add(New Data With {
                .ID = 2,
                .ParentID = 1,
                .Title = "A"
            })
            data.Add(New Data With {
                .ID = 3,
                .ParentID = 1,
                .Title = "B"
            })
            data.Add(New Data With {
                .ID = 4,
                .ParentID = 1,
                .Title = "C"
            })
            data.Add(New Data With {
                .ID = 5,
                .ParentID = 2,
                .Title = "A1"
            })
            data.Add(New Data With {
                .ID = 6,
                .ParentID = 2,
                .Title = "A2"
            })
            data.Add(New Data With {
                .ID = 7,
                .ParentID = 2,
                .Title = "A3"
            })
            data.Add(New Data With {
                .ID = 8,
                .ParentID = 3,
                .Title = "B1"
            })
            data.Add(New Data With {
                .ID = 9,
                .ParentID = 3,
                .Title = "B2"
            })
            data.Add(New Data With {
                .ID = 10,
                .ParentID = 4,
                .Title = "C1"
            })
            data.Add(New Data With {
                .ID = 11,
                .ParentID = 8,
                .Title = "B1A"
            })
            data.Add(New Data With {
                .ID = 12,
                .ParentID = 8,
                .Title = "B1B"
            })
            HttpContext.Current.Session("Data") = data
        End If

        Return data
    End Function

    Sub MoveNodes(ByVal nodeKeys As Integer(), ByVal parentID As Integer)
        Dim data = GetData()

        Dim processedNodes = data.Join(nodeKeys, Function(x) x.ID, Function(y) y, Function(x, y) x)

        For Each node In processedNodes
            If processedNodes.Where(Function(x) x.ID = node.ParentID).Count() = 0 Then
                If node.ParentID = 0 Then
                    MakeParentNodeRoot(parentID)
                End If
                node.ParentID = parentID
            End If
        Next
    End Sub

    Sub MoveNode(ByVal nodeID As Integer, ByVal parentID As Integer)
        Dim data = GetData()
        data.Find(Function(x) x.ID = nodeID).ParentID = parentID
    End Sub

    Sub MakeParentNodeRoot(ByVal id As Integer)
        GetData().Find(Function(x) x.ID = id).ParentID = 0
    End Sub
End Module
