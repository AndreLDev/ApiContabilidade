﻿namespace ApiContabilidade.Models.AuthenticationModels
{
    public class TokenModel
    {
        public string? Token { get; set; }
        public DateTime ValidTo { get; set; }
    }

}
