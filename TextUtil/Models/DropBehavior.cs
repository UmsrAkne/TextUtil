﻿namespace TextUtil.Models
{
    using System.IO;
    using System.Windows;
    using Microsoft.Xaml.Behaviors;
    using TextUtil.ViewModels;

    public class DropBehavior : Behavior<Window>
    {
        protected override void OnAttached()
        {
            base.OnAttached();

            // ファイルをドラッグしてきて、コントロール上に乗せた際の処理
            AssociatedObject.PreviewDragOver += this.AssociatedObject_PreviewDragOver;

            // ファイルをドロップした際の処理
            AssociatedObject.Drop += this.AssociatedObject_Drop;
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.PreviewDragOver -= this.AssociatedObject_PreviewDragOver;
            AssociatedObject.Drop -= this.AssociatedObject_Drop;
        }

        private void AssociatedObject_Drop(object sender, DragEventArgs e)
        {
            // ファイルパスの一覧の配列
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            var vm = ((Window)sender).DataContext as MainWindowViewModel;

            // アプリの性質上、複数のファイルを扱うことはないので、仮に複数のファイルがドロップされたとしても先頭のファイルのみを取得する。
            vm.CurrentFileInfo = new System.IO.FileInfo(files[0]);
        }

        private void AssociatedObject_PreviewDragOver(object sender, DragEventArgs e)
        {
            e.Effects = DragDropEffects.Copy;
            e.Handled = e.Data.GetDataPresent(DataFormats.FileDrop);
        }
    }
}