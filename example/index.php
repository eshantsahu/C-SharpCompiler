<!DOCTYPE html>
<html>
<head>
	<title> Online compilers</title>
	<script type="text/javascript" src='js/jquery.min.js'></script>
	<script type="text/javascript" src='js/cloud.js'></script>
	<style type="text/css">
	*
	{
		margin: 0;
		padding: 0;
	}
	body
	{
		margin: 0 auto;
		width:100%;
		height: 100%;
	}
	#program
	{
		width:60%;
		height: 200px;
		clear: right;
		margin-bottom: 30px;
	}
	.output
	{
		width: 60%;
		min-height: 100px;
	}
	.main
	{
		padding-top: 50px;
		margin: 0 auto;
	}
	#submit
	{
		padding: 3px;
	}
</style>
</head>
<body>
	<?php
	$sampleProgram='
using System;
namespace Example1
{
class Program
{
 
 static void Main(string[] args)
  {
    Console.WriteLine("Welcome to Compilers.");
  }
}
}';
	echo @"
	<div class='main' align='center'>
		<h3> C# Compiler Ver 1.0</h3>
		<br/>
		File Name * : <input type='text' name='user' id='user'>
		<br/><br/>
		<textarea id='program'> $sampleProgram </textarea>
		<br/>
		<button id='submit' value='Compile' >Compile Me</button>
		<br/>
		<div class='output' style='text-align:left;border:solid #c0c0c0 1px;'>
		</div>
	</div>
	";

	?>

</body>
</html>



