   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5   	       WpfApp1.LoginWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp1     5   	     � Title$  Авторизация��5   	   $	��450��6   $	��800��6*   .��5	      �  � ColumnDefinitions 5
   
   .+�5   
   �� -   5         ��Name$ login��5      $ ��Введите логин:��6   $
��Left=�68   $��225,131,0,0q�6S   $	��Top=�6h   $��14(�6�   �� 5   
   -   5        $ Password��5      $"��Введите пароль:��6"   $
��Left=�6<   $��216,188,0,0q�6W   $	��Top=�6l   $��14(�6�   �� 5   
   -   5         ��Name$ LoginBox��5      $
��Left=�6$   $��351,136,0,0q�6?    �� TextWrapping$
 Wrap=�6T   $	��Top=�6h   $	��120��6�   G� 5   
   -   5         G�Name$ PasswordField��5      $
��Left=�6-   $��351,193,0,0q�6H   $	��Top=�6]   $	��120��6u   �� 5   
   -   5         ��Name$ LoginButton��5      $��Вход��6&   $
��Left=�65   $��273,266,0,0q�6P   $	��Top=�6e   $��14(�6}   $��86��6�   6�   �� 5   
   -   5        $ RegistrationButton��5      $��Регистрация��6-   $
��Left=�6C   $��390,266,0,0q�6^   $	��Top=�6s   $��14(�6�   $	��101��6�   6�   5      5      