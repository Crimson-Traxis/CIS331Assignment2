Public Class ToppingItem

    Public Event RemoveItem(ByVal sender As Object, ByVal e As EventArgs)

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
    End Sub

    Public Sub New(toppping As Topping)

        ' This call is required by the designer.
        InitializeComponent()
        Me.Topping = toppping

    End Sub

    Private Sub buttonRemove_Click(sender As Object, e As RoutedEventArgs) Handles buttonRemove.Click
        RaiseEvent RemoveItem(Me, New EventArgs())
    End Sub

    Public Property Topping() As Topping
        Get
            Dim value As String = textBlockTopping.Text
            value = value.Replace(" ", "_")
            Dim top As Topping
            top = [Enum].Parse(GetType(Topping), value)
            Return top
        End Get
        Set(ByVal value As Topping)
            Dim top As String = value.ToString()
            top = top.Replace("_", " ")
            textBlockTopping.Text = top
        End Set
    End Property
End Class
