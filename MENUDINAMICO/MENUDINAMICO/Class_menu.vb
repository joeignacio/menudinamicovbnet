Public Class Class_menu
    Inherits Class_conexion

    Function listar_menu_dinamico() As DataTable
        Dim dt As New DataTable
        Dim obj_conexion As New Class_conexion
        Try
            Dim da As New SqlClient.SqlDataAdapter("SELECT * FROM dbo.MENU WITH (NOLOCK)", obj_conexion.conectar)
            da.Fill(dt)
            obj_conexion.desconectar()
        Catch ex As Exception
            obj_conexion.desconectar()
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return dt
    End Function

End Class
