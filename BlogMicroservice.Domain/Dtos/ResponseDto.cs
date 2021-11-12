using System.Collections.Generic;


namespace BlogMicroservice.Domain.Dtos
{
    public class ResponseDto
    {
        /*
         Esta clase la utilizaremos para cuando un usuario genere
        una solicitud al sistema y nosotros le enviemos la respuesta
        por medio de las propiedades de esta clase
         */
        public bool IsSuccess { get; set; } = true;
        public object Result { get; set; }
        public string DisplayMessage { get; set; }
        public List<string> ErrorMessage { get; set; }
    }
}
