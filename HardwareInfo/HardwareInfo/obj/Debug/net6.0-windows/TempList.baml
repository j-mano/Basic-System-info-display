   M S B A M L   `   `   `  ????G  CHardwareInfo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:HardwareInfoHardwareInfo  5   	       HardwareInfo.TempList   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:HardwareInfo     5   	     ? Title$  TempList??5   	   $	??264??6   $	??310??6'    ? 
ResizeMode$ CanMinimize=?63   .??5	      ?  ? ColumnDefinitions 5
   
   ?? 5      $
??700* ?6   ?? 5      $
??109* ?6   .+?5   
   ?? -   5         ??Name$ label??5      $??Temprature sensors
??6   $
??Left=?6F   $??	10,10,0,0q?6a   $	??Top=?6t   $??24??6?    ? Cursor$
 None??6?   ?? 5   
   -   5        $ 
label_Copy??5      $??
Cpu temp:
??6$   $
??Left=?6=   $??	24,39,0,0q?6X   $	??Top=?6k   $??24??6?   ?? 5   
   -   5        $ label_Copy1??5      $??Cpu temp value
??6%   $
??Left=?6C   $??	91,39,0,0q?6^   $	??Top=?6q   $??24??6?   ?? 5   
   -   5        $ label_Copy2??5      $??
Ram temp:
??6%   $
??Left=?6>   $??	24,63,0,0q?6Y   $	??Top=?6l   $??24??6?   ?? 5   
   -   5        $ label_Copy3??5      $??Ram temp value
??6%   $
??Left=?6C   $??	91,63,0,0q?6^   $	??Top=?6q   $??24??6?   ?? 5   
   -   5        $ label_Copy4??5      $??
GPU temps
??6%   $
??Left=?6>   $??	24,87,0,0q?6Y   $	??Top=?6l   $??24??6?   ?? 5   
   -   5         ??Name$ listBox??5      $??24,111,10,10q?6N   $??2??6d   5      5      