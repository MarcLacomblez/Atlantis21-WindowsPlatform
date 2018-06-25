' REMARQUE : vous pouvez utiliser la commande Renommer du menu contextuel pour changer le nom de classe "Service1" dans le code, le fichier svc et le fichier de configuration.
' REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez Service1.svc ou Service1.svc.vb dans l'Explorateur de solutions et démarrez le débogage.
Public Class Service1
	Implements IService1

	Public Sub New()
	End Sub

	Public Function GetData(ByVal value As Integer) As String Implements IService1.GetData
		Return String.Format("You entered: {0}", value)
	End Function

	Public Function GetDataUsingDataContract(ByVal composite As CompositeType) As CompositeType Implements IService1.GetDataUsingDataContract
		If composite Is Nothing Then
			Throw New ArgumentNullException("composite")
		End If
		If composite.BoolValue Then
			composite.StringValue &= "Suffix"
		End If
		Return composite
	End Function

End Class
