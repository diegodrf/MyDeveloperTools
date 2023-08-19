using MyDeveloperTools.App.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDeveloperTools.UnitTest.MyDeveloperTools.App.Test.Constants.Test
{
    public class RouteConstantsTest
    {
        [Fact]
        public void WhenCallMethodToListRoutes_ShouldReturnAListOfRoutes()
        {
            var routes = RouteConstant.GetAllRoutes();

            Assert.NotEmpty(routes);
        }

        [Fact]
        public void WhenCallMethodToGetRelativePath_ShouldReturnRelativePath()
        {
            var absolutePath = RouteConstant.GetAllRoutes().First();
            var relativePath = absolutePath.GetRelativePath();

            Assert.Equal(absolutePath[1..], relativePath);
        }

        [Fact]
        public void WhenCallMethodToGetPathTitle_ShouldReturnPathAsCaptalizedName()
        {
            var absolutePath = RouteConstant.GetAllRoutes().First(x => x.Equals("/tools/base64-converter"));
            var title = absolutePath.GetPathTitle();

            Assert.Equal("Base64 Converter", title);
        }
    }
}
