   M S B A M L   `   `   `  ����L  HInventory_Control, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Inventory_Control.pagesInventory_Control.pages  5      -    'Inventory_Control.pages.PermissionsPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:Inventory_Control.pages     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5        N� Title$  PermissionsPage��5       N� 
FontFamily$ Bahnschrift Light)�5       � 	Resources 5         
BlurWindow �� 
TargetType �� Property �� Value-  'System.Windows.Media.Effects.BlurEffect   Radius��%|   &	        �� 5   
   " �6#   .�5      ��  �@J�Effect 5        5      $ 1Q�6!   5      5      5      .��5      � $
��Auto��5   	   $��Stretch=�5   	     OptionalBrush#���  5    	    � ColumnDefinitions 5!   
   �� 5"      $��* �6   .+�5&   
   � $��1��6   $��0q�6    � RowDefinitions 5'      �� 5(      $	��600 �6    .+�5*      �� $��4��5+      #���  5,      #���  5-      $��1q�5.      	 �� CornerRadius$	 0��5/      � 50      $��0��51      $��5,5,5,0q�52        SectionBrush#���  53      .+�54      �� $��15q�55        HeaderBrush#���  56      $��2q�57      $	 4��58      ._�59      �  5:      �� 5;      $��75 �6,   �� 5<      $��* �6,   .+�5>      �� #���  6!   $	 4��6M   ._�5?      �� .+�5@   "   �� 
 �� Orientation$
 
Horizontal=�6-   .+�5A   &   �� $
��1050��5B   )   $��10,0,0,0q�5C   )   $
��Left=�5D   )   $
��Left=�5E   )   $��Center=�5F   )   #���  5G   )   $��0,0,0,0q�5H   )   $��USUARIOS��5I   )   $��25(�5J   )     PrimaryBrush#���  5K   )   �� 5L   &   -   5         ��Name$ AddUser��5M   )   $��15,5,0,5q�5N   )   $��Right=�5O   )   $��Agregar usuario��5Q   )    � Cursor$
 Hand��5R   )     GeneralButton#���  5S   )   5T   #   �� 5U   "   $��Bottom=�5V   %     TertiaryBrush#���  5W   %   #���  5X   %   $��0,2,0,2q�5Y   %   ._�5Z   &   �� $
 
Horizontal=�61   .+�5[   *   �� $��50��5\   -   $��Center=�5]   -   #���  5^   -   $��0,0,2,0q�5_   -   $��ID��5`   -     	FontBrush#���  5a   -   �� 5b   *   $	��250��5c   -   $��Center=�5d   -   #���  5e   -   $��0,0,2,0q�5f   -   $��NOMBRE��5g   -   #���  5h   -   �� 5i   *   $	��250��5j   -   $��Center=�5k   -   #���  5l   -   $��0,0,2,0q�5m   -   $��EMAIL��5n   -   #���  5o   -   �� 5p   *   $	��150��5q   -   $��Center=�5r   -   #���  5s   -   $��0,0,2,0q�5t   -   $��PERMISOS��5u   -   #���  5v   -   5w   '   5x   #   5y      5z      �� 5{      $��1��5|      
�������$	 0,0,4,4��5~      ._�5      �� $��Visible=�6+   .��5�   "   �� $
 Vertical=�6-   .+�5�   &   �� -   5         ��Name$ 
usersTable��5�   1   5�   #   5�      5�      5�      5�      5�      5�      5�      5�      