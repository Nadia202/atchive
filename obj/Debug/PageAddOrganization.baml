   M S B A M L   `   `   `  ����=  9PP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:PPPP  5          PP.PageAddOrganization   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      "localclr-namespace:PP     5      _ [MaterialDesignThemes.Wpf, Version=4.4.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5        N� FontSize$  16(�5	       N� Title$ PageAddOrganization��5      .��5      � 
�������.+�5   
   �  � ColumnDefinitions 5      �� 5      �� 5      $
��auto �6#   �� 5       � RowDefinitions 5      �� 5      $��50��6    �� 5      $
��auto �6    �� 5      $��50��6    .+�5      �� $��1��5      $��1��5      $��Center=�5      $��Center=�5      $	��400��5      $	��500��5      
������ �� CornerRadius$ 15��5!       �� Padding$ 20q�5"       J� Effect 5#      3  -System.Windows.Media.Effects.DropShadowEffect  5$         
BlurRadius$ 30Q�6#      ShadowDepth$ 10Q�63   	   Color$	 Green��6D   6T   ._�5&      �� .+�5'      �� -   5        
 ��Name$
 
innTextBox��5'      $
��10 5q�5(      $��Black"�5)      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ ИНН��5+       �� 	MaxLength$ 10��5,      /  )MaterialDesignThemes.Wpf.TransitionAssist   DisableTransitions .  %  !MaterialDesignFloatingHintTextBox#��[  5.      �� 50      -   5        $
 directorTextBox��50      $
��10 5q�51      $��Black"�52      $ Директор��53      #��[  54       � Cursor$ Arrow��6U   �� 56      -   5         ��Name$ opfComboBox��56       �� DisplayMemberPath$
 type��58      $
��10 5q�59      $��Black"�5:      $ ОПФ��5;       & "MaterialDesignFloatingHintComboBox#��[ 5<       �� SelectedItem 57      �� *	TypeOPF+5<      �� 5>      -   5        $
 nameTextBox��5>      $
��10 5q�5?      $��Black"�5@      $ Название��5A      #��[  5B      �� 5D      -   5        $
 
kppTextBox��5D      $
��10 5q�5E      $��Black"�5F      $ 9��5H       . $ КПП��5J      #��[  5K      �� 5M      -   5        $
 ogrnTextBox��5M      $
��10 5q�5N      $��Black"�5O      $ 13��5Q       . $ ОГРН��5S      #��[  5T      �� 5V      -   5        $
 addressTextBox��5V      $
��10 5q�5W      $��Black"�5X      $ 
Адрес��5Y      #��[  5Z      �� 5\      -   5         ��Name$ btnSave��5\      $��60 20q�5]      $��Сохранить��5^      5_      5`      5a      �� 5b      -	   5        $ btnExit��5b      $��2��5c      $��2��5d       . *MaterialDesignFloatingActionMiniDarkButton#��[ 5e      $
��Left=�5f      $	��Top=�5g      $��0q�5h      $��40��5i      $��40��5j      .��5l      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ ArrowLeftCircleOutline=�6*   $��40��5m   &   $��40��5n   &   5o      5p      5q      5r      