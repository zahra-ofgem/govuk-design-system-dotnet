using System;
using System.Threading.Tasks;
using ApprovalTests;
using ApprovalTests.Namers;
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

        [Theory]
        [InlineData("Hint", typeof(HintViewModel))]
        [InlineData("Label", typeof(LabelViewModel))]
        public async Task Rendering(string viewName, Type viewModelType)
        {
            // Tell ApprovalTests how to name these test results
            NamerFactory.AdditionalInformation = viewName;

            // Arrange
            var renderer = GetViewRenderer();
            var viewModel = Activator.CreateInstance(viewModelType);

            // Act
            var result = await renderer.Render(viewName, viewModel);

            // Assert
            Approvals.VerifyHtml(result);
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
