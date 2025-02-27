﻿'  ---------------------------------------------------------------------------------
'  ---------------------------------------------------------------------------------
'   Document    :  FolderExportErrorEventArgs.vb
'   Description :  [type_description_here]
'   Created     :  3/6/2015 10:34:01 AM
'   <copyright company="ECMG">
'       Copyright (c) Enterprise Content Management Group, LLC. All rights reserved.
'       Copying or reuse without permission is strictly forbidden.
'   </copyright>
'  ---------------------------------------------------------------------------------
'  ---------------------------------------------------------------------------------

#Region "Imports"

Imports System.ComponentModel
Imports Documents.Utilities

#End Region

Namespace Arguments

  Public Class FolderExportErrorEventArgs
    Inherits FolderErrorEventArgs

#Region "Public Properties"

    Public ReadOnly Property SourceDocumentId() As String
      Get
        Return MyBase.FolderId
      End Get
    End Property

#End Region

#Region "Constructors"

    ' RaiseEvent FolderExportError(Me, New ExportErrorEventArgs(Args.Id, String.Format(Args.Id, "ID: {0} :{1}", Args.Id, ex.Message), ex))
    ' Where Args is ExportFolderEventArgs

    Public Sub New(ByVal lpMessage As String,
                   ByVal lpException As Exception)
      MyBase.New(lpMessage, lpException)
    End Sub

    Public Sub New(ByVal lpMessage As String,
                   ByVal lpException As Exception,
                   ByVal lpWorker As BackgroundWorker)
      MyBase.New(lpMessage, lpException, lpWorker)
    End Sub

    Public Sub New(ByVal lpExportArgs As ExportFolderEventArgs,
                   ByVal lpException As Exception)
      MyBase.New(lpExportArgs, lpException)
    End Sub

    Public Sub New(ByVal lpExportArgs As ExportFolderEventArgs,
                   ByVal lpException As Exception,
                   ByVal lpWorker As BackgroundWorker)
      MyBase.New(lpExportArgs, lpException, lpWorker)
    End Sub

    Public Sub New(ByVal lpSourceFolderId As String,
                   ByVal lpMessage As String,
                   ByVal lpException As Exception)
      MyBase.New(lpSourceFolderId, lpMessage, lpException)
    End Sub

    Public Sub New(ByVal lpSourceFolderId As String,
                   ByVal lpMessage As String,
                   ByVal lpException As Exception,
                   ByVal lpWorker As BackgroundWorker)
      MyBase.New(lpSourceFolderId, lpMessage, lpException, lpWorker)
    End Sub

#End Region

#Region "Private Methods"

    Protected Friend Overrides Function DebuggerIdentifier() As String
      Try
        If SourceDocumentId.Length > 0 Then
          Return String.Format("SourceFolderId={0}; {1}", SourceDocumentId, MyBase.DebuggerIdentifier)
        Else
          Return MyBase.DebuggerIdentifier
        End If
      Catch ex As Exception
        ApplicationLogging.LogException(ex, Reflection.MethodBase.GetCurrentMethod)
        ' Re-throw the exception to the caller
        Throw
      End Try
    End Function

#End Region

  End Class

End Namespace