   M S B A M L   `   `   `  ����  WpfApplication39    3WpfApplication3.CreateEditWindows.WorkingTimeWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   $��372.537��5   	   $	��420��6     � 
ResizeMode$  NoResize=�6&    � WindowStartupLocation$ CenterScreen=�6<    � ShowInTaskbar .  .��5      � .+�5   
   �� .+�5      �� $��Eingabe per��6   $��Right=�6,   $	��160��6H   .��5      �  � Orientation$ 
Horizontal=�6   $
��10,5q�65   .+�5	      �� .+�5
      	� -   5         	�Name$ radiobutton_time��5
   &    d� 	IsChecked$
 TrueY�6A   $��Uhrzeit��6R   6d   5      �� 5      $��10,0,0,0q�6!   .+�5      	� -   5        $ radiobutton_term��5   &   $��Dauer��6@   6P   5      5      5      �� 5      $��0,0,10,0q�6   ��5      �� 5      $��18(�6   .��6*   Arbeitszeit67   .��5      �� .+�5      �� $
��Left=�6!    �� Orientation$ 
Horizontal=�6<   .+�5      �� �� 5      $��Arbeitszeit-Nr.:��6$    �� 5      -   5         ��Name$ textbox_workingtimenr��5   &   $��60��6E   5      �� 5      �� 5      $��Datum:��6$    (  "System.Windows.Controls.DatePicker  5      -   5          Name$ datepicker_date��5   )   $	��148��6B   5      5      �� 5       $
��Left=�6!   $ 
Horizontal=�6<   .+�5!      �� �� 5"      -   5        	 ��Name$	 label_workingTimeFrom��5"   $   $
��Von:��6C    �� 5#      -   5        $ textbox_workingTimeFrom��5#   &   $��50��6G   5$      �� 5%      �� 5&      -   5        $	 label_workingTimeTill��5&   $   $
��Bis:��6C    �� 5'      -   5        $ textbox_workingTimeTill��5'   &   $��50��6G   5(      �� 5)      �� 5*      -	   5        $	 label_workingTimeTerm��5*   $   $��Dauer:��6C   $y�	Collapsed=�6T    �� 5+      -
   5        $ textbox_workingTimeTerm��5+   &   $��60��6G   $y�	Collapsed=�6R   5,      5-      5.      5/      �� 50      $��0,0,10,0q�6   ��51      �� 52      $��18(�6   .��6*   Informationen69   .��54      �� .+�55      �� $ 
Horizontal=�6!   $
��Left=�6:   .+�56      �� �� 57      $��Projekt:��6$    �� 58      -   5        
 ��Name$
 combobox_project��58   '   $	��120��6A   59      �� 5:      �� 5;      $��Aktivität:��6$    �� 5<      -   5        $
 combobox_activity��5<   '   $	��120��6B   5=      5>      5?      5@      �� 5A      $��0,0,10,0q�6   ��5B      �� 5C      $��18(�6   .��6*   Pause61   .��5E      �� .+�5F      �� $ 
Horizontal=�6!   $
��Left=�6:   .+�5G      �� �� 5H      -   5        $	 label_pauseFrom��5H   $   $
��Von:��6=    �� 5I      -   5        $ textbox_pauseFrom��5I   &   $��50��6A   5J      �� 5K      �� 5L      -   5        $	 label_pauseTill��5L   $   $
��Bis:��6=    �� 5M      -   5        $ textbox_pauseTill��5M   &   $��50��6A   5N      �� 5O      �� 5P      -   5        $	 label_pauseTerm��5P   $   $��Dauer:��6=   $y�	Collapsed=�6N    �� 5Q      -   5        $ textbox_pauseTerm��5Q   &   $��50��6A   $y�	Collapsed=�6L   5R      5S      5T      5U      5V      � 5W   
   $��2��6   .+�5X      �� -   5         ��Name$ button_create��5X      $��Anlegen��6,   $��	0,0,20,10q�6>   $��Bottom=�6Q   $��30��6l   $��Right=�6�   $	��104��6�   �� 5Y      -   5        $ button_back��5Y      $��Zurück��6*   $��	20,0,0,10q�6;   $��Bottom=�6N   $��30��6i   $
��Left=�6�   $��90��6�   5Z      5[      5\      