Public Class NumberUpDown

    Public Event NumberChanged(ByVal sender As Object, ByVal e As EventArgs)
    Private minVal As Long
    Private maxVal As Long

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
        minVal = Long.MinValue
        maxVal = Long.MaxValue
    End Sub

    Private Sub textBoxQuantity_TextChanged(sender As Object, e As TextChangedEventArgs) Handles textBoxNumber.TextChanged
        RaiseEvent NumberChanged(Me, New EventArgs)
        Dim tempInt As Long = 0
        Long.TryParse(textBoxNumber.Text, tempInt)
        Number = tempInt
    End Sub

    Private Sub buttonQuantityAdd1_Click(sender As Object, e As RoutedEventArgs) Handles buttonAdd1.Click
        Number = Number + 1
    End Sub

    Private Sub buttonQuantitySubtract1_Click(sender As Object, e As RoutedEventArgs) Handles buttonSubtract1.Click
        Number = Number - 1
    End Sub

    Public Property Number() As Long
        Get
            Dim tempInt As Long = 0
            Long.TryParse(textBoxNumber.Text, tempInt)
            Return tempInt
        End Get
        Set(ByVal value As Long)
            If value < minVal Then
                textBoxNumber.Text = minVal
            ElseIf value > maxVal Then
                textBoxNumber.Text = maxVal
            Else
                textBoxNumber.Text = value
            End If

        End Set
    End Property

    Public Property MinValue() As Long
        Get
            Return minVal
        End Get
        Set(ByVal value As Long)
            minVal = value
        End Set
    End Property

    Public Property MaxValue() As Long
        Get
            Return maxVal
        End Get
        Set(ByVal value As Long)
            maxVal = value
        End Set
    End Property

    Public WriteOnly Property InitailNumber() As Long
        Set(ByVal value As Long)
            Number = value
        End Set
    End Property
End Class
