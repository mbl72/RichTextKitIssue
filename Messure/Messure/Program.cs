namespace Messure
{
    using SkiaSharp;
    using Topten.RichTextKit;

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            var image = new SKBitmap(800, 400);
            var rs = new RichString
            {
                MaxWidth = 800,
                MaxHeight = 480,
            }
            .FontSize(20)
            .BackgroundColor(SKColors.White)
            .LineHeight(1.1f)
            .Alignment(TextAlignment.Center)
            .Add("Test");

            using (SKCanvas bitmapCanvas = new SKCanvas(image))
            {
                using (var textPaint = new SKPaint { Color = SKColors.White, TextSize = 60, IsAntialias = true })
                {
                    bitmapCanvas.DrawRect(0, 100, image.Width, 30, textPaint);
                    textPaint.Color = SKColors.Coral;
                    bitmapCanvas.DrawText("TestTestTestTestTestTestTestTest", new SKPoint(10, 100), textPaint);
                    var top = (image.Height - rs.MeasuredHeight) / 2;
                    SKData d = image.Encode(SKEncodedImageFormat.Png, 100);

                    using (Stream s = File.OpenWrite("output.png"))
                    {
                        d.SaveTo(s);
                    }
                }
            }
        }
    }
}