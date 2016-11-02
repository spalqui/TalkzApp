
Partial Class main
    Inherits System.Web.UI.Page


    <System.Web.Services.WebMethod()>
    Public Function insertMessageToDB(ByVal data As String) As String
        Return data
    End Function


End Class
