using XamarinBoilerplate.Core.Test.Service;
using XamarinBoilerplate.iOS.Service;
using Xunit;

namespace XamarinBoilerplate.iOS.Test.Service
{
    public class AssetServiceiOSTest : AssetServiceTest
    {
        public AssetServiceiOSTest() : base(new AssetServiceiOS())
        {
        }

        [Fact]
        public void ReadAssetText_ShouldLoadTextFromFile()
        {
            base.ReadAssetText_ShouldLoadTextFromFile("Text/asset_sample_text_file.txt", "iOS test text");
        }
    }
}