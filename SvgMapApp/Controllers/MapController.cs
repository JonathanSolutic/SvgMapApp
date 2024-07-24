 using Microsoft.AspNetCore.Mvc;
using SvgMapApp.Models;
using SvgMapApp.Services;

namespace SvgMapApp.Controllers
{
    public class MapController : Controller
    {
        private readonly SvgMapGenerator _generator;

        public MapController()
        {
            _generator = new SvgMapGenerator();
        }
        public IActionResult Index()
        {
            var coordinates = new List<GpsCoordinate>
                {
                new GpsCoordinate { Latitude = 37.7749, Longitude = -122.4194 },// San Francisco
                new GpsCoordinate { Latitude = 34.0522, Longitude = -118.2437 }, // Los Angeles
                new GpsCoordinate { Latitude = 40.7128, Longitude = -74.0060 }, // New York
                new GpsCoordinate { Latitude = 51.5074, Longitude = -0.1278 }    // London

                //les coordontes du Data center Mutanda
                //new GpsCoordinate { Latitude = -10.79452, Longitude = 25.79313 },
                //new GpsCoordinate { Latitude = -10.79441, Longitude = 25.79314 },
                //new GpsCoordinate { Latitude = -10.79443, Longitude = 25.79304 },
                //new GpsCoordinate { Latitude = -10.79455, Longitude = 25.79308},
            };

            var svgContent = _generator.GenerateSvg(coordinates);

            ViewData["SvgContent"] = svgContent;
            return View();
        }
    }
}
