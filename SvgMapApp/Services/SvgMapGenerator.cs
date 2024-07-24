using SvgMapApp.Models;
using System.Globalization;
using System.Text;
using System.Xml;

namespace SvgMapApp.Services
{
    public class SvgMapGenerator
    {
        public string GenerateSvg(IEnumerable<GpsCoordinate> coordinates)
        {
            var sb = new StringBuilder();

            sb.AppendLine("<svg id=\"svgMap\" width=\"800\" height=\"600\" viewBox=\"0 0 800 600\" xmlns=\"http://www.w3.org/2000/svg\">");
            sb.AppendLine("<rect width=\"800\" height=\"600\" fill=\"#f0f0f0\" />");

            var points = new List<string>();
            int id = 0;

            foreach (var coordinate in coordinates)
            {
                var x = (coordinate.Longitude + 180) * (800 / 360.0);
                var y = (90 - coordinate.Latitude) * (600 / 180.0);

                points.Add($"{x.ToString(CultureInfo.InvariantCulture)},{y.ToString(CultureInfo.InvariantCulture)}");

                sb.AppendLine($"<circle cx=\"{x.ToString(CultureInfo.InvariantCulture)}\" cy=\"{y.ToString(CultureInfo.InvariantCulture)}\" r=\"5\" fill=\"red\">");
                sb.AppendLine($"<title>Coordinate {++id}: ({coordinate.Latitude}, {coordinate.Longitude})</title>");
                sb.AppendLine($"</circle>");
            }

            sb.AppendLine($"<polyline points=\"{string.Join(" ", points)}\" stroke=\"blue\" stroke-width=\"2\" fill=\"none\" />");

            sb.AppendLine("</svg>");
            return sb.ToString();
        }
    }
}
