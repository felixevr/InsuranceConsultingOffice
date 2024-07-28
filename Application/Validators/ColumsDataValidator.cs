using InsuranceConsultingOffice.Application.Bases;
using InsuranceConsultingOffice.Utilities;

namespace InsuranceConsultingOffice.Application.Validators
{
    public static class ColumsDataValidator
    {
        public static BaseResponse<bool> ColumnsDataValidor(string[] columns)
        {
            var response = new BaseResponse<bool>();

            if (columns.Length < 4)
            {
                response.IsSuccess = false;
                response.Message = string.Format(ReplyMessage.MESSAGE_MINIMUN_COLUMNS_NEEDED, columns[0]);
                return response;
            }

            if (string.IsNullOrWhiteSpace(columns[0]) || string.IsNullOrWhiteSpace(columns[1]) || string.IsNullOrWhiteSpace(columns[2]))
            {
                response.IsSuccess = false;
                response.Message = ReplyMessage.MESSAGE_CAN_NOT_BE_EMPTY_OR_NULL;
                return response;
            }

            if (!int.TryParse(columns[3], out int age))
            {
                response.IsSuccess = false;
                response.Message = string.Format(ReplyMessage.MESSAGE_IS_NOT_VALID_NUMBER, columns[0]);
                return response;
            }

            response.IsSuccess = true;

            return response;
        }
    }
}
