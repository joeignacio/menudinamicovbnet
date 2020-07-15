Public Class FrmMenuprincipal

    Friend WithEvents menuStrip1 As New MenuStrip
    Friend WithEvents nivel_cero As ToolStripMenuItem
    Friend WithEvents nivel_uno As ToolStripMenuItem
    Friend WithEvents nivel_dos As ToolStripMenuItem
    Friend WithEvents nivel_tres As ToolStripMenuItem

    Dim dt_tabla As New DataTable
    Dim obj_menu As New Class_menu

    Private Sub FrmMenuprincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'crear_tabla()
        crear_menu_dinamico()
    End Sub

    Sub crear_menu_dinamico()

        dt_tabla = obj_menu.listar_menu_dinamico

        For i As Integer = 0 To dt_tabla.Rows.Count - 1

            Select Case dt_tabla.Rows(i).Item("nivel").ToString

                Case "0"
                    nivel_cero = New ToolStripMenuItem(dt_tabla.Rows(i).Item("descripcion").ToString)
                    menuStrip1.Items.Add(nivel_cero)

                Case "1"
                    nivel_uno = New ToolStripMenuItem(dt_tabla.Rows(i).Item("descripcion").ToString)
                    nivel_cero.DropDownItems.Add(nivel_uno)
                    AddHandler nivel_uno.Click, AddressOf eventoClick

                Case "2"
                    nivel_dos = New ToolStripMenuItem(dt_tabla.Rows(i).Item("descripcion").ToString)
                    nivel_uno.DropDownItems.Add(nivel_dos)
                    AddHandler nivel_dos.Click, AddressOf eventoClick

                Case "3"
                    nivel_tres = New ToolStripMenuItem(dt_tabla.Rows(i).Item("descripcion").ToString)
                    nivel_dos.DropDownItems.Add(nivel_tres)
                    AddHandler nivel_tres.Click, AddressOf eventoClick

            End Select

            Controls.Add(menuStrip1)
        Next

    End Sub

    Private Sub eventoClick(ByVal sender As System.Object, ByVal e As EventArgs)

        Dim nuevo_formulario As New Form 'instanciar nuevo formulario

        'With nuevo_formulario 
        '    .MdiParent = Me
        '    If .IsHandleCreated = True Then
        '        .BringToFront()
        '    Else
        '        .Show()
        '        .Text = DirectCast(sender, ToolStripMenuItem).Text
        '    End If
        'End With

        With nuevo_formulario
            .MdiParent = Me
            .Show()
            .Text = DirectCast(sender, ToolStripMenuItem).Text
        End With
    End Sub

    Sub crear_tabla()

        dt_tabla = New DataTable("MENU")

        dt_tabla.Columns.Add("idmenudinamico")
        dt_tabla.Columns.Add("nivel")
        dt_tabla.Columns.Add("descripcion")

        Dim dr As DataRow

        dr = dt_tabla.NewRow()
        dr("idmenudinamico") = "1"
        dr("nivel") = "0"
        dr("descripcion") = "Mantenimientos"
        dt_tabla.Rows.Add(dr)

        dr = dt_tabla.NewRow()
        dr("idmenudinamico") = "2"
        dr("nivel") = "1"
        dr("descripcion") = "Productos"
        dt_tabla.Rows.Add(dr)

        dr = dt_tabla.NewRow()
        dr("idmenudinamico") = "3"
        dr("nivel") = "1"
        dr("descripcion") = "Clientes"
        dt_tabla.Rows.Add(dr)

        dr = dt_tabla.NewRow()
        dr("idmenudinamico") = "4"
        dr("nivel") = "1"
        dr("descripcion") = "Proveedores"
        dt_tabla.Rows.Add(dr)

        dr = dt_tabla.NewRow()
        dr("idmenudinamico") = "5"
        dr("nivel") = "0"
        dr("descripcion") = "Operaciones"
        dt_tabla.Rows.Add(dr)

        dr = dt_tabla.NewRow()
        dr("idmenudinamico") = "6"
        dr("nivel") = "1"
        dr("descripcion") = "Ventas"
        dt_tabla.Rows.Add(dr)

        dr = dt_tabla.NewRow()
        dr("idmenudinamico") = "7"
        dr("nivel") = "2"
        dr("descripcion") = "Registrar Ventas"
        dt_tabla.Rows.Add(dr)

        dr = dt_tabla.NewRow()
        dr("idmenudinamico") = "8"
        dr("nivel") = "2"
        dr("descripcion") = "Lista de Ventas"
        dt_tabla.Rows.Add(dr)

        dr = dt_tabla.NewRow()
        dr("idmenudinamico") = "9"
        dr("nivel") = "1"
        dr("descripcion") = "Compras"
        dt_tabla.Rows.Add(dr)

        dr = dt_tabla.NewRow()
        dr("idmenudinamico") = "10"
        dr("nivel") = "2"
        dr("descripcion") = "Registrar Compras"
        dt_tabla.Rows.Add(dr)

        dr = dt_tabla.NewRow()
        dr("idmenudinamico") = "11"
        dr("nivel") = "1"
        dr("descripcion") = "Movimientos de Caja"
        dt_tabla.Rows.Add(dr)

        dr = Nothing
    End Sub

    Private Sub FrmMenuprincipal_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If MsgBox("Desea realmente salir", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Menu Principal") = MsgBoxResult.Yes Then
            For Each ChildForm As Form In MdiChildren
                ChildForm.Close()
                If Application.OpenForms.Count = 0 Then Exit For
            Next
            Dispose()
            Application.Exit()
        Else
            e.Cancel = True
        End If
    End Sub

End Class
