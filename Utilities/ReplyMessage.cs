namespace InsuranceConsultingOffice.Utilities
{
    public class ReplyMessage
    {
        public const string MESSAGE_SUCCESS = "Consulta exitosa. ";
        public const string MESSAGE_NO_POLICIES_FOUND = "Disculpa! No hay seguros con este código. ";
        public const string MESSAGE_INSURANCE_ALREADY_EXIST = "El código de seguro que intentas registrar ya existe. ";
        public const string MESSAGE_CLIENT_ALREADY_EXIST = "El número de cédula de cliente {0} que intentas registrar ya existe. ";
        public const string MESSAGE_INSURANCE_ID_DOES_NOT_EXIST = "El ID del seguro que intentas editar no existe. ";
        public const string MESSAGE_CLIENT_ID_DOES_NOT_EXIST = "El ID de cliente que intentas editar no existe. ";
        public const string MESSAGE_IDCARD_NUMBER_ALREADY_ASSIGNED = "El Número de identidad {0} que intentas asignar ya existe en la base de datos o está duplicado. ";
        public const string MESSAGE_INSURANCE_CODE_ALREADY_ASSIGNED = "El código de seguro que intentas asignar ya existe en la base de datos o está duplicado. ";
        public const string MESSAGE_ERROR_TO_SAVE_IN_DB = "Falló el registro en la base de datos. ";
        public const string MESSAGE_ERROR_TO_DELETE = "El registró que deseas eliminar no existe. ";
        public const string MESSAGE_SUCCESS_TO_DELETE = "El registró fue eliminado exitosamente. ";
        public const string MESSAGE_SUCCESS_TO_REGISTER = "Se registró exitosamente. ";
        public const string MESSAGE_INSURED_DOES_NOT_EXIST = "Disculpa! No hay clientes con este número de idetificación. ";
        public const string MESSAGE_CODE_WAS_ASSIGNED = "El código de seguro fue asignado. ";
        public const string MESSAGE_MINIMUN_COLUMNS_NEEDED = "Se esperan al menos 4 columnas de datos. Asegurese que no falta ningún dato para el cliente: {0}. ";
        public const string MESSAGE_CAN_NOT_BE_EMPTY_OR_NULL = "Uno o más campos obligatorios están vacíos o son null. Asegurese que no falta ningún dato para el cliente: {0}. ";
        public const string MESSAGE_IS_NOT_VALID_NUMBER = "El campo edad del cliente con número de cédula '{0}' no es un entero válido. ";
        public const string MESSAGE_CLIENT_ALREADY_HAS_ASSIGNAMENT = "Ya tiene asignado el seguro con id {0}. ";
        public const string MESSAGE_CLIENT_AGE_OUT_OF_RANGE = "La edad del cliente {0} esta fuera de rango. No fue posible asignarle la póliza. ";
        public const string MESSAGE_CLIENT_REGISTER_FATAL_ERROR = "¡Fatal Error! Algún problema ocurrió durante el registro. ";
        public const string MESSAGE_CLIENT_CARDID = "{0} ";
        public const string MESSAGE_POLICY_ID_DOES_NOT_EXIST = "El id de seguro (policyId) que intenta asignar no existe. ";
        public const string MESSAGE_CHECK_POLICY_CONFIGURATION = "No fue posible asignarle la póliza. Revise la configuración de asignación de polizas. Es posible que el Id de la poliza que desea asignar no existe en la base de datos. ";
        public const string MESSAGE_ANOTHER_CLIENT_HAS_THE_SAME_IDCARD = "Existe otro cliente registrado con la cédula: {0}. Si el cliente es el mismo, asegurate de actualizar sus datos antes de volver a intentar asignarle una poliza. ";

    }
}
