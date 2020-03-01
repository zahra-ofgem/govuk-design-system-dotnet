using System;
using System.Threading.Tasks;
using ApprovalTests;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace GovUkDesignSystem.SnapshotTests.Helpers
{
    public abstract class SnapshotTestBase
    {
        private readonly ComponentTestServerFixture _server;

        internal SnapshotTestBase()
        {
            _server = new ComponentTestServerFixture();
        }

        protected async Task VerifyPartial(string viewName, object viewModel)
        {
            var serviceProvider = _server.GetRequiredService<IServiceProvider>();
            var viewEngine = _server.GetRequiredService<IRazorViewEngine>();
            var tempDataProvider = _server.GetRequiredService<ITempDataProvider>();

            var viewRenderer = new ViewRenderer(viewEngine, tempDataProvider, serviceProvider);

            var result = await viewRenderer.Render(viewName, viewModel);

            Approvals.VerifyHtml(result);
        }
    }
}
