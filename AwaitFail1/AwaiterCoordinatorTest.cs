using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace AwaitFail1
{

static class AwaiterCoordinatorTest
{
static AsyncCoordinator coordinator;


public static void run ()
{
	// create a coroutine with the async coordinator
	coordinator=new AsyncCoordinator();
	coordinator.scheduleCoroutine (w_doJob1);

	// run until it ends
	while (coordinator.RunStep())
	{
		Console.WriteLine ("Step ran");
	}

	Console.WriteLine ("No more steps to run");
}

/// <summary>Coroutine function. Should print all the steps until the end.</summary>
static async Task w_doJob1 (AsyncCoordinator coord)
{
	Console.WriteLine ("    step 1");
	await coord;

	Console.WriteLine ("    step 2");
	await coord;

	Console.WriteLine ("    step 3");
	await coord;
}



}



}
