namespace InsuranceConsultingOffice.Application.Models.FileUploadProcess
{
    /// <summary>
    /// El número asignado al rango de edad representa el ID de la Poliza (policyId) que se asigna 
    /// automaticamente a ese rango de edad determinado.
    /// </summary>
    public enum FileUploadProcessConfigurationPolicyAssignament
    {   
        EDAD_DE_0_A_17 = 1,   
        EDAD_DE_18_A_30 = 2,
        EDAD_DE_31_A_45 = 5,
        EDAD_DE_46_A_60 = 6,
        EDAD_DE_61_A_120 = 3,
    } 
}
