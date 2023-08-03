namespace HotelsHubApp.Business.Helper
{
    public static class GenerateKey
    {
        public static string CreateKey(List<string> rateKey, int roomCount) => roomCount switch
        {
            1 => $"{roomCount}½{rateKey[0]}${Guid.NewGuid()}",
            2 => $"{roomCount}½{rateKey[0]}&{rateKey[1]}${Guid.NewGuid()}",
            3 => $"{roomCount}½{rateKey[0]}&{rateKey[1]}&{rateKey[2]}${Guid.NewGuid()}",
            4 => $"{roomCount}½{rateKey[0]}&{rateKey[1]}&{rateKey[2]}&{rateKey[3]}${Guid.NewGuid()}",
            5 => $"{roomCount}½{rateKey[0]}&{rateKey[1]}&{rateKey[2]}&{rateKey[3]}&{rateKey[4]}${Guid.NewGuid()}",
            _ => throw new NotImplementedException()
        };
    }
}
