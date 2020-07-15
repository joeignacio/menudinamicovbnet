Imports System.Data.SqlClient

Public Module Module_variables

    'variable de conexión
    '==========================================================================================
    Public cn As New SqlConnection

    'variables para las transacciones
    '==========================================================================================
    Public myTrans As SqlTransaction 'controla las transacciones
    Public Comando As SqlCommand 'para utilizar tipos de comandos
    Public estado_transaccion As String = "" 'estado que se encuentra una transaccion

    'variables de acceso a la base de datos
    '===========================================================================================
    Public Servidor As String = "DESKTOP-S64QC04" 'nombre del servidor
    Public ususql As String = "sa" 'usuario del servidor
    Public clavesql As String = "j20071124" 'contraséña del servidor
    Public BaseDatos As String = "BD" '"BDMENUDINAMICO" 'nombre de la Base de Datos

End Module
