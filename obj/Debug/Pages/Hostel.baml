   M S B A M L   `   `   `  ����R  NWpf_DataBase_Hostel_App, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:Wpf_DataBase_Hostel_App.PagesWpf_DataBase_Hostel_App.Pages  5      *    $Wpf_DataBase_Hostel_App.Pages.Hostel   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      =local+clr-namespace:Wpf_DataBase_Hostel_App.Pages     5        N� Title$  Hostel��5	      .��5      �  � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   $	��200��6)   �� 5      $��3 �6   �� 5      $	��500 �6   $	��200��6+   .+�5   
   �� $��Общежитие��6   $��26(�6$   $��	ExtraBold"�62   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ RoomsDataGrid��5      $��1��6*      AutoGenerateColumns .     CanUserAddRows .  
�������   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Комната��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 10* 6W   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 66   �� 
 �� Path$
 ID_Room�6W   5      �� 5   
   -   5         ��Name$ HostelGridSplitter��5      $��1��63   $��1��6C   $��3��6P   $��Stretch=�6Z     5!   
   -   5        $ StudentsDataGrid��5!      $��1��6|   $��2��6�    .   .  
���������6-   ��  �� ElementName$ RoomsDataGrid��$
 SelectedItem.Students� 5"        5#      $ Студент��6%   $	 10* 66   	 5$      `� 5%       �� StringFormat$ {0} {1} {2}��6'   .1�5&      �� $
 F�6&   �� 5'      $
 I�6&   �� 5(      $
 O�6&   5)      5+      5-      5.      5/      