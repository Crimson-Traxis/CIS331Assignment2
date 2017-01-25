'------------------------------------------------------------ 
'-                File Name : NumberUpDown.xaml.vb          - 
'-                Part of Project: Assignment 2             - 
'------------------------------------------------------------
'-                Written By: Trent Killinger               - 
'-                Written On: 1-14-17                       - 
'------------------------------------------------------------ 
'- File Purpose:                                            - 
'-                                                          - 
'- This file is contains the events ,properties for         -
'- setting min/max and logic for the control                -
'------------------------------------------------------------
'- Variable Dictionary                                      - 
'- NumberChanged – event that fires when the number is      -
'- changed                                                  -
'- minVal - minimum value for control                       -
'- maxVal - maximum value for control                       -
'------------------------------------------------------------
Public Class NumberUpDown

    Public Event NumberChanged(ByVal sender As Object, ByVal e As EventArgs)
    Private minVal As Long
    Private maxVal As Long

    '------------------------------------------------------------ 
    '-                Subprogram Name: New                      - 
    '------------------------------------------------------------
    '-                Written By: Trent Killinger               - 
    '-                Written On: 1-14-17                       - 
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      - 
    '-                                                          - 
    '- This subroutine creates the control                      -
    '------------------------------------------------------------ 
    '- Parameter Dictionary:                                    - 
    '- (None)                                                   - 
    '------------------------------------------------------------ 
    '- Local Variable Dictionary:                               - 
    '- (None)                                                   - 
    '------------------------------------------------------------
    Public Sub New()
        InitializeComponent()
        minVal = Long.MinValue
        maxVal = Long.MaxValue
    End Sub

    '------------------------------------------------------------ 
    '-         Subprogram Name: textBoxQuantity_TextChanged     - 
    '------------------------------------------------------------
    '-                Written By: Trent Killinger               - 
    '-                Written On: 1-14-17                       - 
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      - 
    '-                                                          - 
    '- This subroutine raises the NumberChanged event allowing  -
    '- control to signal when the number has changed            -
    '------------------------------------------------------------ 
    '- Parameter Dictionary:                                    - 
    '- sender – Identifies which particular control raised the  - 
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -    
    '------------------------------------------------------------ 
    '- Local Variable Dictionary:                               - 
    '- tempInt - temporary int                                  - 
    '------------------------------------------------------------
    Private Sub textBoxQuantity_TextChanged(sender As Object, e As TextChangedEventArgs) Handles textBoxNumber.TextChanged
        RaiseEvent NumberChanged(Me, New EventArgs)
        Dim tempInt As Long = 0
        Long.TryParse(textBoxNumber.Text, tempInt)
        Number = tempInt
    End Sub

    '------------------------------------------------------------ 
    '-         Subprogram Name: buttonQuantityAdd1_Click        - 
    '------------------------------------------------------------
    '-                Written By: Trent Killinger               - 
    '-                Written On: 1-14-17                       - 
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      - 
    '-                                                          - 
    '- This subroutine adds one to the number value             -
    '------------------------------------------------------------ 
    '- Parameter Dictionary:                                    - 
    '- sender – Identifies which particular control raised the  - 
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -    
    '------------------------------------------------------------ 
    '- Local Variable Dictionary:                               - 
    '- (none)                                                   - 
    '------------------------------------------------------------
    Private Sub buttonQuantityAdd1_Click(sender As Object, e As RoutedEventArgs) Handles buttonAdd1.Click
        Number = Number + 1
    End Sub

    '------------------------------------------------------------ 
    '-         Subprogram Name: buttonQuantitySubtract1_Click   - 
    '------------------------------------------------------------
    '-                Written By: Trent Killinger               - 
    '-                Written On: 1-14-17                       - 
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      - 
    '-                                                          - 
    '- This subroutine subtracts one to the number value        -
    '------------------------------------------------------------ 
    '- Parameter Dictionary:                                    - 
    '- sender – Identifies which particular control raised the  - 
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -    
    '------------------------------------------------------------ 
    '- Local Variable Dictionary:                               - 
    '- (none)                                                   - 
    '------------------------------------------------------------
    Private Sub buttonQuantitySubtract1_Click(sender As Object, e As RoutedEventArgs) Handles buttonSubtract1.Click
        Number = Number - 1
    End Sub

    '------------------------------------------------------------ 
    '-                Property Name: Number                     - 
    '------------------------------------------------------------
    '-                Written By: Trent Killinger               - 
    '-                Written On: 1-14-17                       - 
    '------------------------------------------------------------
    '- Property Purpose:                                        - 
    '-                                                          - 
    '- This Property sets/sets the number of the control and    -
    '- determines if the value is below/above the min and max.  -
    '- if value is above/below the property will replace value  -
    '- with preset min/max                                      -
    '------------------------------------------------------------ 
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

    '------------------------------------------------------------ 
    '-                Property Name: MinValue                   - 
    '------------------------------------------------------------
    '-                Written By: Trent Killinger               - 
    '-                Written On: 1-14-17                       - 
    '------------------------------------------------------------
    '- Property Purpose:                                        - 
    '-                                                          - 
    '- This Property sets/sets the min value of the control     -
    '------------------------------------------------------------ 
    Public Property MinValue() As Long
        Get
            Return minVal
        End Get
        Set(ByVal value As Long)
            minVal = value
        End Set
    End Property

    '------------------------------------------------------------ 
    '-                Property Name: MinValue                   - 
    '------------------------------------------------------------
    '-                Written By: Trent Killinger               - 
    '-                Written On: 1-14-17                       - 
    '------------------------------------------------------------
    '- Property Purpose:                                        - 
    '-                                                          - 
    '- This Property sets/sets the max value of the control     -
    '------------------------------------------------------------
    Public Property MaxValue() As Long
        Get
            Return maxVal
        End Get
        Set(ByVal value As Long)
            maxVal = value
        End Set
    End Property

    '------------------------------------------------------------ 
    '-                Property Name: MinValue                   - 
    '------------------------------------------------------------
    '-                Written By: Trent Killinger               - 
    '-                Written On: 1-14-17                       - 
    '------------------------------------------------------------
    '- Property Purpose:                                        - 
    '-                                                          - 
    '- This Property sets/sets the inital value of the control  -
    '------------------------------------------------------------
    Public WriteOnly Property InitailNumber() As Long
        Set(ByVal value As Long)
            Number = value
        End Set
    End Property
End Class
