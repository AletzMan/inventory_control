   M S B A M L   `   `   `  ����L  HInventory_Control, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Inventory_ControlInventory_Control  5      "    Inventory_Control.MainWindow   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:Inventory_Control     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      -   5          � Title$  Inventory Control��5      $
��1400��5	      $	��900��5
       � AllowsTransparency . 
������  � 
ResizeMode$ NoResize=�5       � WindowStartupLocation$ CenterScreen=�5       � WindowStyle$
 None=�5      .��5      � -   5         �Name$ mainGrid��5   	   $
��1400��5   	   $	��900��5   	   
������  � ColumnDefinitions 5   
   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      $��* �6   .+�5   
   � 
������ .+�5       �� -   5         ��Name$ TopBar��5!      $��0q�5"         PrimaryBrush#���   5#      	 �� CornerRadius$	 	10,10,0,0��5$      �� 5%      $��10,5,0,0q�5&      $��Inventory Management��5'      $��13(�5(        	FontBrush#���  5)      �� 5*      -   5        
 ��Name$
 minimizeButton��5+      $��
1270,0,0,0q�5,        ButtonMinimize#��[ 5.      �� 5/      -   5        $
 closeButton��50      $��
1350,0,5,0q�51        ButtonClose#��[ 53      54      � 56   
   -   5        $ contentGrid��57      $��1��58        OptionalBrush#���  59       5:      �� 5;      $	��150 �6#   �� 5<      $��* �6#   .+�5>      �� -   5         ��Name$ NavigationMenu��5?      $��0��5@        SecondaryBrush#���  5A      .+�5B      � $
��Auto��5C      $��40��5D      #���  5E      �� 5F      -   5        $
 dashboardButton��5G      #���   5H        
menuButton#���  5L      .��5M      �� $	��140��5N      $��0q�5O       �� Orientation$ Vertical=�5P      .+�5Q      �� $��20��5R      $��assets/dashboard.png��5S        imageButton#��[ 5T      �� 5U      $��Center=�5V      $��Center=�5W      $��	Dashboard��5X      5Y      5Z      �� 5[      -	   5        $
 permissionButton��5\      #���  5`      .��5a      �� $	��140��5b      $��0q�5c      $��Stretch=�5d      $ Vertical=�5e      .+�5f      �� $��30��5g      $��assets/access.png��5h      #��[ 5i      �� 5j      $��Center=�5k      $��Center=�5l      $��Users��5m      5n      5o      �� 5p      -
   5        $
 supplierButton��5q      #���  5u      .��5v      �� $	��140��5w      $��0q�5x      $��Stretch=�5y      $ Vertical=�5z      .+�5{      �� $��assets/suppliers.png��6    #��[ 6>   �� 5|      $��Center=�5}      $��Center=�5~      $��	Suppliers��5      5�      5�      �� 5�      -   5        $
 salesButton��5�      #���  5�      .��5�      �� $	��140��5�      $��0q�5�      $��Stretch=�5�      $ Vertical=�5�      .+�5�      �� $��assets/sales.png��6    #��[ 6:   �� 5�      $��Center=�5�      $��Center=�5�      $��Sales��5�      5�      5�      �� 5�      -   5        $
 inventoryButton��5�      #���  5�      .��5�      �� $	��140��5�      $��0q�5�      $��Stretch=�5�      $ Vertical=�5�      .+�5�      �� $��assets/inventory.png��6    #��[ 6>   �� 5�      $��Center=�5�      $��Center=�5�      $��	Inventory��5�      5�      5�      �� 5�      -   5        $
 reportButton��5�      #���  5�      .��5�      �� $	��140��5�      $��0q�5�      $��Stretch=�5�      $ Vertical=�5�      .+�5�      �� $��assets/report.png��6    #��[ 6;   �� 5�      $��Center=�5�      $��Center=�5�      $��Report��5�      5�      5�      5�      �� 5�      $��1��5�      $
��Auto��5�      $
��Auto��5�      $��Stretch=�5�      $��Stretch=�5�      .+�5�       � -   5          �Name$ viewPage��5�      $
��Auto��5�      $
��Auto��5�      $��Stretch=�5�      $��Stretch=�5�        � NavigationUIVisibility$ Hidden=�5�      5�      5�      5�      5�      