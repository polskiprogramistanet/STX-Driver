namespace STX_Driver.src.Common
{
    public interface IPinDecoder
    {
        string DecodePinReader();
        bool PinCardComparator(string cardPin, string readerPin);
        bool PinCardComparator(string cardPin);
    }
}