using System;
using System.Threading.Tasks;
using GovUkDesignSystem.GovUkDesignSystemComponents;
using GovUkDesignSystem.SnapshotTests.Helpers;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Xunit;

namespace GovUkDesignSystem.SnapshotTests
{
    public class RenderingTests
    {
        private readonly ComponentTestServerFixture _server;

        public RenderingTests()
        {
            _server = new ComponentTestServerFixture();
        }

        [Fact]
        public async Task Rendering_Label_ExpectSuccess()
        {
            // Arrange
            var renderer = GetViewRenderer();
            var viewModel = new LabelViewModel();

            // Act
            var result = await renderer.Render(@"Label", viewModel);

            // Assert
            Assert.NotNull(result);
        }

        private ViewRenderer GetViewRenderer()
        {
            var serviceProvider = _server.GetRequiredService<IServiceProvider>();
            var viewEngine = _server.GetRequiredService<IRazorViewEngine>();
            var tempDataProvider = _server.GetRequiredService<ITempDataProvider>();

            var viewRenderer = new ViewRenderer(viewEngine, tempDataProvider, serviceProvider);
            return viewRenderer;
        }
    }
}
