namespace NNPTPZ1
{
    /// <summary>
    /// Size of the output image and the rendered area of the complex plane.
    /// </summary>
    public class FractalSettings
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public double XMin { get; set; }
        public double XMax { get; set; }
        public double YMin { get; set; }
        public double YMax { get; set; }
        public string OutputPath { get; set; }

        public double XStep => (XMax - XMin) / Width;
        public double YStep => (YMax - YMin) / Height;

        /// <summary>
        /// Expected arguments: width height xmin xmax ymin ymax output
        /// </summary>
        public static FractalSettings FromArguments(string[] args)
        {
            return new FractalSettings()
            {
                Width = int.Parse(args[0]),
                Height = int.Parse(args[1]),
                XMin = double.Parse(args[2]),
                XMax = double.Parse(args[3]),
                YMin = double.Parse(args[4]),
                YMax = double.Parse(args[5]),
                OutputPath = args[6]
            };
        }
    }
}
