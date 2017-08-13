using XamarinBoilerplate.Core.Test.Service;
using XamarinBoilerplate.Droid.Service;
using Xunit;

namespace XamarinBoilerplate.Droid.Test.Service
{
    public class AssetServiceiOSTest : AssetServiceTest
    {
        public AssetServiceiOSTest() : base(new AssetServiceDroid())
        {
        }

        [Fact]
        public void ReadAssetText_ShouldLoadTextFromFile()
        {
            base.ReadAssetText_ShouldLoadTextFromFile("Text/asset_sample_text_file.txt", "Droid test text");
        }
    }
}