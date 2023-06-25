Public Class RelationshipCounselor

'Declare variables
Public Shared allClients As New Dictionary(Of String, Client)
Public Shared allSessions As New List(Of Session)

'Class definitions
Public Class Client
  Public Property ID As String
  Public Property Name As String
  Public Property Phone As String
  Public Property Email As String
  Public Property ProblemDescription As String
  Public Property SessionsCompleted As Integer
End Class

Public Class Session
  Public Property ID As String
  Public Property ClientID As String
  Public Property Date As Date
  Public Property Notes As String
End Class

'Public methods
Public Sub RequestAppointment(client As Client)
  allClients.Add(client.ID, client)
End Sub

Public Sub ScheduleAppointment(appointment As Session)
  allSessions.Add(appointment)
End Sub

Public Sub CancelAppointment(clientID As String, sessionID As String)
  allSessions.Remove(allSessions.Find(Function(x) x.ClientID = clientID And x.ID = sessionID))
End Sub

Public Function GetSessionsByClientID(clientID As String) As List(Of Session)
  Return allSessions.FindAll(Function(x) x.ClientID = clientID)
End Function

Public Function GetClientByID(clientID As String) As Client
  Return allClients(clientID)
End Function

Public Function GetClientCount() As Long
  Return allClients.Count
End Function

Public Function GetCompletedSessionCount() As Long
  Return allSessions.Count
End Function

End Class