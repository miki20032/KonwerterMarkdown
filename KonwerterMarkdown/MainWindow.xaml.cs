using System;
using System.Windows;
using Markdig;
using HtmlAgilityPack;

namespace MarkdownHtmlConverter
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ConvertToHtml_Click(object sender, RoutedEventArgs e)
        {
            string markdown = MarkdownTextBox.Text;
            string html = Markdown.ToHtml(markdown);
            HtmlTextBox.Text = html;
        }

        private void ConvertToMarkdown_Click(object sender, RoutedEventArgs e)
        {
            string html = HtmlTextBox.Text;
            var doc = new HtmlDocument();
            doc.LoadHtml(html);
            string markdown = ConvertHtmlToMarkdown(doc);
            MarkdownTextBox.Text = markdown;
        }

        private void ClearFields_Click(object sender, RoutedEventArgs e)
        {
            MarkdownTextBox.Clear();
            HtmlTextBox.Clear();
        }

        private string ConvertHtmlToMarkdown(HtmlDocument doc)
        {
            var converter = new ReverseMarkdown.Converter();
            return converter.Convert(doc.DocumentNode.OuterHtml);
        }
    }
}
