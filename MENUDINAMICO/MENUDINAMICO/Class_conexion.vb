
Public Class Class_conexion

    Function conectar() As SqlClient.SqlConnection
        Dim mensaje As String
        cn.ConnectionString = "Data Source=" & Servidor & "; Initial Catalog=" & BaseDatos & ";User ID=" & ususql & ";password=" & clavesql & ""

        Try
            cn.Open()
        Catch ex As SqlClient.SqlException
            Select Case ex.Number
                Case 2
                    mensaje = "Servidor Detenido"
                Case 17142
                    mensaje = "Servidor Pausado"
                Case 53
                    mensaje = "No se pudo encontrar el servidor"
                Case 4060
                    mensaje = "No se encontró la base de datos"
                Case 18456
                    mensaje = "Usuario o Clave incorrectas"
                Case Else
                    mensaje = ex.Message
            End Select

            MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Application.Exit()
        End Try
        Return cn
    End Function

    Sub desconectar()
        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If
    End Sub

End Class
