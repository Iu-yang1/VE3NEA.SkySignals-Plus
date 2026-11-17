using System.Linq;
using VE3NEA.SkyTlm.Telemetry;
using Xunit;

namespace VE3NEA.SkyTlm.Tests.Unit
{
  public sealed class Asrtu1HeaderTests
  {
    [Fact]
    public void ShortTmHeaderMaintainsAo123Fields()
    {
      byte[] raw = { 0x45, 0xA4, 0x11, 0x22, 0xFF };
      var fields = Asrtu1Header.Describe(raw).ToDictionary(x => x.Name, x => x.Value);
      Assert.Equal(61781, Asrtu1Header.NoradId);
      Assert.Equal("1", fields["Version"]);
      Assert.Equal("90", fields["Spacecraft ID"]);
      Assert.Equal("2", fields["Virtual channel"]);
      Assert.Equal("No", fields["OCF present"]);
      Assert.Equal("17", fields["Master frame count"]);
      Assert.Equal("34", fields["Virtual channel frame count"]);
      Assert.Equal("255", fields["First header pointer"]);
      Assert.Empty(Asrtu1Header.Describe(new byte[4]));
    }
  }
}
