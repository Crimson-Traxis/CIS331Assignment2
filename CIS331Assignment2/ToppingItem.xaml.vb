'------------------------------------------------------------ 
'-                File Name : ToppingItem.xaml.vb            - 
'-                Part of Project: Assignment 2             - 
'------------------------------------------------------------
'-                Written By: Trent Killinger               - 
'-                Written On: 1-14-17                       - 
'------------------------------------------------------------ 
'- File Purpose:                                            - 
'-                                                          - 
'- This file is contains the events ,properties for         -
'- hidding the remove button and properties for converting  -
'- between topping and textbox string for the topping item  -
'- control                                                  -
'------------------------------------------------------------
'- Variable Dictionary                                      - 
'- RemoveItem – event that fires when the remove button is  -
'-              clicked                                     -
'------------------------------------------------------------

Public Class ToppingItem

    Public Event RemoveItem(ByVal sender As Object, ByVal e As EventArgs)

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
    End Sub

    '------------------------------------------------------------ 
    '-                Subprogram Name: New                      - 
    '------------------------------------------------------------
    '-                Written By: Trent Killinger               - 
    '-                Written On: 1-14-17                       - 
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      - 
    '-                                                          - 
    '- This subroutine creates the gui and instantiates default -
    '- topping in the control
    '------------------------------------------------------------ 
    '- Parameter Dictionary:                                    - 
    '- (None)                                                   - 
    '------------------------------------------------------------ 
    '- Local Variable Dictionary:                               - 
    '- (None)                                                   - 
    '------------------------------------------------------------
    Public Sub New(toppping As Topping)

        InitializeComponent()
        Me.Topping = toppping

    End Sub

    '------------------------------------------------------------ 
    '-                Subprogram Name: buttonPrevious_Click     - 
    '------------------------------------------------------------
    '-                Written By: Trent Killinger               - 
    '-                Written On: 1-14-17                       - 
    '------------------------------------------------------------
    '- Subprogram Purpose:                                      - 
    '-                                                          - 
    '- This subroutine raises the remove event allowing this    -
    '- control to be removed from its partent control           -
    '------------------------------------------------------------ 
    '- Parameter Dictionary:                                    - 
    '- sender – Identifies which particular control raised the  - 
    '-          click event                                     - 
    '- e – Holds the EventArgs object sent to the routine       -    
    '------------------------------------------------------------ 
    '- Local Variable Dictionary:                               - 
    '- (None)                                                   - 
    '------------------------------------------------------------
    Private Sub buttonRemove_Click(sender As Object, e As RoutedEventArgs) Handles buttonRemove.Click
        RaiseEvent RemoveItem(Me, New EventArgs())
    End Sub

    '------------------------------------------------------------ 
    '-                Property Name: Topping                    - 
    '------------------------------------------------------------
    '-                Written By: Trent Killinger               - 
    '-                Written On: 1-14-17                       - 
    '------------------------------------------------------------
    '- Property Purpose:                                        - 
    '-                                                          - 
    '- This Property sets/sets the topping of the control       -
    '------------------------------------------------------------  
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

    '------------------------------------------------------------ 
    '-                Property Name: Topping                    - 
    '------------------------------------------------------------
    '-                Written By: Trent Killinger               - 
    '-                Written On: 1-14-17                       - 
    '------------------------------------------------------------
    '- Property Purpose:                                        - 
    '-                                                          - 
    '- This Property sets/gets the visibility of the remove     -
    '- button                                                   -
    '------------------------------------------------------------ 
    Public Property RemoveButtonVisibility() As Visibility
        Get
            Return buttonRemove.Visibility
        End Get
        Set(ByVal value As Visibility)
            buttonRemove.Visibility = value
        End Set
    End Property
End Class
