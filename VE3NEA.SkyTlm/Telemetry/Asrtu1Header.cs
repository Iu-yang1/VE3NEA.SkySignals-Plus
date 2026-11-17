namespace VE3NEA.SkyTlm.Telemetry
{
  /// <summary>
  /// ASRTU-1 / AO-123 (NORAD 61781) short CCSDS TM transfer-frame header.
  /// The payload is handled separately by the SkyRoof VC0/VC2 short-KISS
  /// reassembler; this class only describes the five-byte transfer header.
  /// See gr-satellites tm_kiss_transport(short_tm=True).
  /// </summary>
  public static class Asrtu1Header
  {
    public const int NoradId = 61781;

    public static IEnumerable<(string Name, string Value)> Describe(byte[] frame)
    {
      if (frame.Length < 5) yield break;
      int version = frame[0] >> 6;
      int spacecraftId = ((frame[0] & 0x3f) << 4) | (frame[1] >> 4);
      int virtualChannel = (frame[1] >> 1) & 0x7;
      bool ocf = (frame[1] & 1) != 0;

      yield return ("Protocol", "CCSDS short TM (ASRTU-1)");
      yield return ("Version", version.ToString());
      yield return ("Spacecraft ID", spacecraftId.ToString());
      yield return ("Virtual channel", virtualChannel.ToString());
      yield return ("OCF present", ocf ? "Yes" : "No");
      yield return ("Master frame count", frame[2].ToString());
      yield return ("Virtual channel frame count", frame[3].ToString());
      yield return ("First header pointer", frame[4].ToString());
    }
  }
}
