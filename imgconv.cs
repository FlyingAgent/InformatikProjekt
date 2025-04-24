using System;
using System.IO;
using ImageMagick;

class Program
{
    static void Main(string[] args)
    {
        // Check if the correct number of arguments is provided
        if (args.Length != 3)
        {
            Console.WriteLine("Usage: convert_image <input.jpg> <output.webp|output.avif> <quality>");
            return;
        }

        // Extract command-line arguments
        string inputFile = args[0];
        string outputFile = args[1];
        string extension = Path.GetExtension(outputFile).ToLower();

        // Validate output file extension
        if (extension != ".webp" && extension != ".avif")
        {
            Console.WriteLine("Output file must have .webp or .avif extension.");
            return;
        }

        // Check if input file exists
        if (!File.Exists(inputFile))
        {
            Console.WriteLine("Input file does not exist.");
            return;
        }

        // Parse and validate quality parameter
        if (!int.TryParse(args[2], out int quality) || quality < 0 || quality > 100)
        {
            Console.WriteLine("Quality must be an integer between 0 and 100.");
            return;
        }

        try
        {
            // Load the image and perform conversion
            using (var image = new MagickImage(inputFile))
            {
                // Verify the input is a JPEG
                if (image.Format != MagickFormat.Jpg)
                {
                    Console.WriteLine("Input file is not a JPEG.");
                    return;
                }

                // Set the quality and save the image
                image.Quality = quality;
                image.Write(outputFile);
            }
            Console.WriteLine("Conversion successful.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}