namespace IMALOpening
{
    public class DLLPS
    {
        public class ReqCreateCIF
        {
            public string? cifType { get; set; }
            public string? idType { get; set; }
            public string? idNumber { get; set; }
            public string? dateOFbirth { get; set; }
            public string? idExpiryDate { get; set; }
            public string? maritalStatus { get; set; }
            public string? gender { get; set; }
            public string? language { get; set; }
            public string? shortName { get; set; }
            public string? longName { get; set; }
            public string? shortNameArabic { get; set; }
            public string? longNameArabic { get; set; }
            public string? nationality { get; set; }
            public string? country { get; set; }
            public string? firstName { get; set; }
            public string? secondName { get; set; }
            public string? thirdName { get; set; }
            public string? lastName { get; set; }
            public string? firstNameArabic { get; set; }
            public string? secondNameArabic { get; set; }
            public string? thirdNameArabic { get; set; }
            public string? lastNameArabic { get; set; }
            public string? block { get; set; }

            public string? blockenglish { get; set; }
            public string? mobile { get; set; }
            public string? area { get; set; }
            public string? addressCountry { get; set; }
            public string? modeOfStatementDelivery { get; set; }
            public string? statement { get; set; }
            public string? economicSector { get; set; }
            public string? legalStatus { get; set; }
            public string? ranking { get; set; }
            public string? occupation { get; set; }
            public string? division { get; set; }
            public string? department { get; set; }
            public string? username { get; set; }
            public string? password { get; set; }

            public string? channelName { get; set; }

            public string? CorpCIF { get; set; }

            public string? CIFBranch { get; set; }
            public string? CorpName { get; set; }

        }

        public class RespCreateCIF
        {
            public string? StatusCode { get; set; }

            public string? StatusDesc { get; set; }

            public string? CIF { get; set; }
        }

        public class ReqValidiateCIF
        {

            public string? CIFno { get; set; }
            public string? autoApproveFlag { get; set; }

            public string? username { get; set; }

            public string? password { get; set; }


        }

        public class RespValidateCIF
        {
            public string? statusCode { get; set; }

            public string? statusDesc { get; set; }
        }

        public class ReqCreateGL
        {
            public string? CIF { get; set; }
            public string? currency { get; set; }
            public string? accGl { get; set; }
            public string? Branch { get; set; }
            public string? username { get; set; }

            public string? Password { get; set; }
            public string? ChannelName { get; set; }
        }

        public class RespCreateGL
        {
            public string? additionalRef { get; set; }

            public string? ibanAccNo { get; set; }

            public string? statusCode { get; set; }

            public string? statusDesc { get; set; }
        }
    }
}
