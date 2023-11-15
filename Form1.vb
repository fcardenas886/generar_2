Imports System.IO

Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim inicio As String
        inicio = "01111"
        Dim i As Integer
        i = CInt(TextBox1.Text)
        ' TextBox1.Text = inicio + i.ToString()


        For x = i To (i + CInt(TextBox2.Text))
            Dim st, texto As String
            Dim caracter As Char

            st = inicio + x.ToString()
            TextBox3.Text = inicio + x.ToString()
            caracter = CalcularDigitoVerificador(st)
            texto = st + "-" + caracter

            escribir(texto)
        Next

    End Sub

    Function CalcularDigitoVerificador(rutSinVerificador As String) As Char
        ' Calcular el dígito verificador
        Dim m As Integer = 2
        Dim s As Integer = 0

        For Each d As Char In StrReverse(rutSinVerificador)
            s += Integer.Parse(d.ToString()) * m
            m = If(m = 7, 2, m + 1)
        Next

        Dim digitoVerificadorCalculado As Integer = (11 - s Mod 11) Mod 11

        ' Convertir el dígito verificador a Char
        If digitoVerificadorCalculado = 10 Then
            Return "K"c
        Else
            Return Char.Parse(digitoVerificadorCalculado.ToString())
        End If
    End Function

    Sub escribir(ByVal s As String)

        ' Ruta del archivo de texto
        Dim filePath As String = "C:\x\txt.txt"

        ' Contenido que deseas escribir en el archivo
        Dim content As String = "Hola, esto es un ejemplo de escritura en un archivo de texto."

        ' Utiliza Using para asegurarte de que el StreamWriter se cierre correctamente al finalizar
        Using writer As New StreamWriter(filePath, True) ' El segundo parámetro (True) indica que se añadirá al archivo si ya existe
            writer.WriteLine(s)
        End Using

    End Sub
End Class
