﻿'<Snippet1>
Imports System.CodeDom

Namespace CodeDomSamples

    Public Class CodeTryCatchFinallyExample

        Public Sub New()
            '<Snippet2>
            ' Declares a type to contain a try...catch block.
            Dim type1 As New CodeTypeDeclaration("TryCatchTest")

            ' Defines a method that throws an exception of type System.ApplicationException.
            Dim method1 As New CodeMemberMethod()
            method1.Name = "ThrowApplicationException"
            method1.Statements.Add(New CodeThrowExceptionStatement( _
                New CodeObjectCreateExpression("System.ApplicationException", New CodePrimitiveExpression("Test Application Exception"))))
            type1.Members.Add(method1)

            ' Defines a constructor that calls the ThrowApplicationException method from a try block.
            Dim constructor1 As New CodeConstructor()
            constructor1.Attributes = MemberAttributes.Public
            type1.Members.Add(constructor1)

            ' Defines a try statement that calls the ThrowApplicationException method.
            Dim try1 As New CodeTryCatchFinallyStatement()
            try1.TryStatements.Add(New CodeMethodInvokeExpression(New CodeThisReferenceExpression(), "ThrowApplicationException"))
            constructor1.Statements.Add(try1)

            ' Defines a catch clause for exceptions of type ApplicationException.
            Dim catch1 As New CodeCatchClause("ex", New CodeTypeReference("System.ApplicationException"))
            catch1.Statements.Add(New CodeCommentStatement("Handle any System.ApplicationException here."))
            try1.CatchClauses.Add(catch1)

            ' Defines a catch clause for any remaining unhandled exception types.
            Dim catch2 As New CodeCatchClause("ex")
            catch2.Statements.Add(New CodeCommentStatement("Handle any other exception type here."))
            try1.CatchClauses.Add(catch2)

            ' Defines a finally block by adding to the FinallyStatements collection.
            try1.FinallyStatements.Add(New CodeCommentStatement("Handle any finally block statements."))

            ' A Visual Basic code generator produces the following Visual Basic source 
            ' code for the preceeding example code:

            '            '------------------------------------------------------------------------------
            '            ' <auto-generated>
            '            '     This code was generated by a tool.
            '            '     Runtime Version:2.0.50727.42
            '            '
            '            '     Changes to this file may cause incorrect behavior and will be lost if
            '            '     the code is regenerated.
            '            ' </auto-generated>
            '            '------------------------------------------------------------------------------

            'Option Strict Off
            'Option Explicit On

            '            'Namespace Samples

            '            Public Class TryCatchTest

            '                Public Sub New()
            '                    MyBase.New()
            '                    Try
            '                        Me.ThrowApplicationException()
            '                    Catch ex As System.ApplicationException
            '                        'Handle any System.ApplicationException here.
            '                    Catch ex As System.Exception
            '                        'Handle any other exception type here.
            '                    Finally
            '                        'Handle any finally block statements.
            '                    End Try
            '                End Sub

            '                Private Sub ThrowApplicationException()
            '                    Throw New System.ApplicationException("Test Application Exception")
            '                End Sub
            '            End Class
            '        End Namespace

            '</Snippet2>

        End Sub
    End Class 'CodeTryCatchFinallyExample 
End Namespace 'CodeDomSamples 
'</Snippet1>