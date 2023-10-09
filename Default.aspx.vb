
Imports System.Data
Imports System.Data.OleDb
Imports System.Web.UI.MobileControls

Partial Class _Default
    Inherits System.Web.UI.Page

    Dim cn As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=B:\3 year 5 sem\external exam\aspcrud\Database7.accdb")

    Dim cmd As OleDbCommand
    Dim dr As OleDbDataReader
    Dim adp As New OleDbDataAdapter
    Dim ds As New DataSet
    Dim no As Integer
    Dim drow As DataRow
    Dim qry As String
    Protected Sub btninsert_Click(sender As Object, e As EventArgs) Handles btninsert.Click
        Try
            Dim str As String
            Dim ans As Integer
            str = "insert into crud(uid,uname,mobile) values(" & txtid.Text & ",'" & txtname.Text & "'," & txtmobile.Text & " ) "
            cn.Open()
            Dim cmd As New OleDbCommand(str, cn)
            ans = cmd.ExecuteNonQuery


            MsgBox("Record Inserted Successfully : " & ans)
            GridView1.DataBind()
            cn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub


    Protected Sub btnupdate_Click(sender As Object, e As EventArgs) Handles btnupdate.Click
        Try
            Dim str As String
            Dim ans As Integer
            str = "Update crud set uname='" & txtname.Text & "',mobile=" & txtmobile.Text & " where uid=" & txtid.Text & "   "
            Dim cmd As New OleDbCommand(str, cn)
            cn.Open()
            ans = cmd.ExecuteNonQuery
            MsgBox("Record Updated Successfully : " & ans)
            GridView1.DataBind()
            cn.Close()

        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Protected Sub btndelete_Click(sender As Object, e As EventArgs) Handles btndelete.Click
        Try
            Dim str As String
            Dim ans As Integer
            str = "Delete from crud where uid=" & txtid.Text & "  "
            Dim cmd As New OleDbCommand(str, cn)
            cn.Open()
            ans = cmd.ExecuteNonQuery
            cn.Close()
            MsgBox("No of Records are : " & ans)
            GridView1.DataBind()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Protected Sub btnsearch_Click(sender As Object, e As EventArgs) Handles btnsearch.Click
        Try
            cn.Open()
            Dim str As String
            str = "Select * from crud where uid=" & txtid.Text & " "
            Dim cmd As New OleDbCommand(str, cn)
            Dim dr As OleDbDataReader
            dr = cmd.ExecuteReader
            While dr.Read
                txtname.Text = dr.Item(1).ToString
                txtmobile.Text = dr.Item(2).ToString


            End While
            GridView1.DataBind()
            cn.Close()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub
End Class
