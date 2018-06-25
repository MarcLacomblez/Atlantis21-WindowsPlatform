' REMARQUE : vous pouvez utiliser la commande Renommer du menu contextuel pour changer le nom d'interface "IService1" à la fois dans le code et le fichier de configuration.
<ServiceContract()>
Public Interface IService1

	<OperationContract()>
	Function GetData(ByVal value As Integer) As String

	<OperationContract()>
	Function GetDataUsingDataContract(ByVal composite As CompositeType) As CompositeType

	' TODO: ajoutez vos opérations de service ici

End Interface

' Utilisez un contrat de données comme indiqué dans l'exemple ci-après pour ajouter les types composites aux opérations de service.

<DataContract()>
Public Class CompositeType

	<DataMember()>
	Public Property BoolValue() As Boolean

	<DataMember()>
	Public Property StringValue() As String

End Class
