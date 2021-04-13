using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Serialization;
using toroinvestimentos.patromonio.domain.Entities.Model.Base;

namespace toroinvestimentos.patromonio.domain.Entities.Model
{
    public class Usuario : BaseEntity
    {
        private string _senhaCriptografada;

        public string Login { get; set; }

        public string Senha { internal get;set; }

        [JsonIgnore]
        public string SenhaCriptografada 
        {
            get 
            {
                if (string.IsNullOrEmpty(_senhaCriptografada))
                {
                    MD5 md5Hash = MD5.Create();
                    byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(this.Senha));
                    StringBuilder sBuilder = new StringBuilder();
                    for (int i = 0; i < data.Length; i++)
                        sBuilder.Append(data[i].ToString("x2"));
                    _senhaCriptografada = sBuilder.ToString();
                }
                return _senhaCriptografada;
            }
            set
            {
                _senhaCriptografada = value;
            }
        }

        public string Token { get; internal set; }

        public DateTime Expiracao { get; internal set; }


        public void generatedData(string userId, string token, DateTime expiracao) 
        {
            this.Id = userId;
            this.Token = token;
            this.Expiracao = expiracao;
        }

    }
}
