// ===========================================================================
// CONTENT  : CLASS Sample1
// AUTHOR   : M.Duchrow
// VERSION  : 1.0 - 23/03/2014
// HISTORY  :
//  23/03/2014  mdu  CREATED
//
// Copyright (c) 2014, by MDCS. All rights reserved.
// ===========================================================================
package org.pfsw.tools.cda.examples;

// ===========================================================================
// IMPORTS
// ===========================================================================
import java.util.ArrayList;
import java.util.Enumeration;
import java.util.List;
import java.util.jar.JarEntry;
import java.util.jar.JarFile;
import java.util.regex.Pattern;
import java.io.*;
import java.util.*;
import java.util.jar.*;
import java.util.Arrays;

import org.pf.text.CommandLineArguments;
import org.pf.tools.cda.base.model.ClassInformation;
import org.pf.tools.cda.base.model.IAnalyzableElement;
import org.pf.tools.cda.base.model.Workset;
import org.pf.tools.cda.base.model.util.StringFilter;
import org.pf.tools.cda.base.model.workset.ClasspathPartDefinition;
import org.pf.tools.cda.core.dependency.analyzer.DependencyAnalyzer;
import org.pf.tools.cda.core.dependency.analyzer.model.DependencyInfo;
import org.pf.tools.cda.core.init.WorksetInitializer;
import org.pf.tools.cda.core.processing.IProgressMonitor;
import org.pf.tools.cda.core.processing.WaitingIElementsProcessingResultHandler;
import org.pf.util.SysUtil;
import org.apache.commons.lang3.ArrayUtils;
import org.json.simple.JSONArray;
import org.json.simple.JSONObject;
import java.io.File; import java.io.FileWriter; 
import java.io.IOException; 
import org.json.simple.JSONArray;
import org.json.simple.JSONObject;

/**
 * An example for working with CDA without GUI.
 *
 * @author M.Duchrow
 * @version 1.0
 */
public class Sample1
{
	// =========================================================================
	// CONSTANTS
	// =========================================================================
	private static final boolean IS_MONITORING = false;
	private static final String CLASS_TO_ANALYZE = "com.jgoodies.common.collect.ArrayListModel";

	// =========================================================================
	// INSTANCE VARIABLES
	// =========================================================================

	// =========================================================================
	// CLASS METHODS
	// =========================================================================
	public static void main(String[] args) throws InterruptedException, IOException
	{




		ArrayList<String> arr = new ArrayList();

		JarFile jarFile = new JarFile("example-libs/LibraryJTP.jar");
		Enumeration enumeration = jarFile.entries();
		while (enumeration.hasMoreElements()) {
			if(processJarFiles(enumeration.nextElement()).endsWith(".class"))
			{
				String cname = processJarFiles(enumeration.nextElement()).replace('/', '.');
				String className = cname.replace(".class", "");
				arr.add(className);
			}
		}






		CommandLineArguments commandArgs;
		Sample1 inst;
		List<String> implementArray = new ArrayList<String>();
		List<String> extendtArray = new ArrayList<String>();
		List<String> useArray = new ArrayList<String>();


		inst = new Sample1();
		/*commandArgs = new CommandLineArguments(args);
    inst.run(commandArgs);*/
		inst.run(arr);

		System.err.flush();
		System.out.flush();
		SysUtil.current().exit(0, 100);
	} // main()

	// =========================================================================
	// CONSTRUCTORS
	// =========================================================================
	public Sample1()
	{
		super();
	} 

	// =========================================================================
	// PROTECTED INSTANCE METHODS
	// =========================================================================
	/*protected void run(CommandLineArguments args)
  {
    Workset workset;
    String sample;

    // Create a workset with a defined classpath
    workset = this.createWorkset();
    // Load all elements on the claspath and pre-analyze them (might take a while!)
    this.initializeWorkset(workset);

    sample = args.getArgumentValue("-sample");

    if ("1".equals(sample))
    {
      this.showClassesMatching(workset, "F.*r$");
    }
    else if ("2".equals(sample))
    {

      this.showDependenciesOf(workset, CLASS_TO_ANALYZE);
    }
    else if ("3".equals(sample))
    {
      this.showAllDependenciesOf(workset, CLASS_TO_ANALYZE);
    }
    else if ("4".equals(sample))
    {
      this.showDependantsOf(workset, CLASS_TO_ANALYZE);
    }
  }*/



	protected void run(ArrayList<String> arr)
	{
		Workset workset;
		String sample;


		JSONObject obj = new JSONObject();
		obj.put("class","go.GraphLinksModel");
		obj.put("nodeKeyProperty", "id");

		JSONArray nodeArray = new JSONArray();
		JSONArray linkArray = new JSONArray();

		// Create a workset with a defined classpath
		workset = this.createWorkset();
		// Load all elements on the claspath and pre-analyze them (might take a while!)
		this.initializeWorkset(workset);
		System.out.println(arr);
		for(String i : arr){
			JSONObject obj1 = new JSONObject();
			obj1.put("category","UndesiredEvent");
			obj1.put("id",i);
			obj1.put("text",i);
			obj1.put("color", "lightyellow");
			nodeArray.add(obj1);

			List<String> list1 = new ArrayList<String>();
			List<String> list2 = new ArrayList<String>();
			List<String> list3 = new ArrayList<String>();
			Object[] listOfArrays = this.showDependenciesOf(workset, i);
			list1 = (List<String>)listOfArrays[0];
			list2 = (List<String>)listOfArrays[1];
			list3 = (List<String>)listOfArrays[2];
			

			if(list1.isEmpty() == false) {
				for(String j : list1){
					JSONObject obj2 = new JSONObject();
					obj2.put("from",i);
					obj2.put("color","#2F4F4F");
					obj2.put("thick", 1.5);
					obj2.put("category", "Realization");
					obj2.put("to", j);
					linkArray.add(obj2);
					
					JSONObject obj1_1 = new JSONObject();
					obj1_1.put("category","UndesiredEvent");
					obj1_1.put("id",j);
					obj1_1.put("text",j);
					obj1_1.put("color", "lightyellow");
					if(!nodeArray.contains(obj1_1)){
						nodeArray.add(obj1_1);
					}
					
				}
			}
			
			if(list2.isEmpty() == false) {
				for(String j : list2){
					JSONObject obj2 = new JSONObject();
					obj2.put("from",i);
					obj2.put("color","#2F4F4F");
					obj2.put("thick", 1.5);
					obj2.put("category", "Generalization");
					obj2.put("to", j);
					linkArray.add(obj2);
					
					JSONObject obj1_1 = new JSONObject();
					obj1_1.put("category","UndesiredEvent");
					obj1_1.put("id",j);
					obj1_1.put("text",j);
					obj1_1.put("color", "lightyellow");
					if(!nodeArray.contains(obj1_1)){
					nodeArray.add(obj1_1);
					}
				}
			}
			
			
			if(list3.isEmpty() == false) {
				for(String j : list3){
					JSONObject obj2 = new JSONObject();
					obj2.put("from",i);
					obj2.put("color","#2F4F4F");
					obj2.put("thick", 1.5);
					obj2.put("category", "DirectedAssociation");
					obj2.put("to", j);
					linkArray.add(obj2);
					
					JSONObject obj1_1 = new JSONObject();
					obj1_1.put("category","UndesiredEvent");
					obj1_1.put("id",j);
					obj1_1.put("text",j);
					obj1_1.put("color", "lightyellow");
					if(!nodeArray.contains(obj1_1)){
						nodeArray.add(obj1_1);
					}
				}
			}



            
			

			/*System.out.println(arr);*/
		}
		
		
		obj.put("nodeDataArray", nodeArray);
		obj.put("linkDataArray", linkArray);
		
		/*this.showDependenciesOf(workset, CLASS_TO_ANALYZE);*/
		try (FileWriter file = new FileWriter("f:\\test.json")) {

			file.write(obj.toString());
			file.flush();

		} catch (IOException e) {
			e.printStackTrace();
		}

	}



	// 
	protected Object[] showDependenciesOf(Workset workset, String className) 
	{
		ClassInformation classInfo;
		ClassInformation[] allClasses;
		ClassInformation[] directlyUseClasses;
		ClassInformation[] directlyImplemntedInterfaces;
		ClassInformation[] directlyExtendedInterfaces;
		ClassInformation[] notUniqClasses;

		// Lookup the class of interest
		classInfo = workset.getClassInfo(className);


		// Get interfaces which are implemented by current class/interface
		directlyImplemntedInterfaces = classInfo.getDirectlyImplementedInterfaces();
		List<String> a1 = this.showResult(directlyImplemntedInterfaces);    
		/*System.out.println("\n\n" + classInfo.getName() + " implements interfaces:");
    System.out.println(a1);*/

		// Get classes which are extended by current class/interface
		directlyExtendedInterfaces = classInfo.getDirectlyExtendedInterfaces();
		List<String> a2 = this.showResult(directlyExtendedInterfaces);    
		/*System.out.println("\n\n" + classInfo.getName() + " extends classes:");
    System.out.println(a2);*/


		// Combine two arrays
		List<String> a12 = new ArrayList<String>(a1);
		a12.addAll(a2);

		// Get classes which are used by current class/interface
		allClasses = classInfo.getReferredClassesArray();
		List<String> a3 = this.showResult(allClasses); 

		// Get unique values
		List<String> duplicateList = new ArrayList<String>();
		List<String> uniqueList = new ArrayList<String>();
		for(String item : a3) {
			if(a12.contains(item)){
				duplicateList.add(item);
			}else{
				uniqueList.add(item);
			}
		}
		/*System.out.println("\n\n" + classInfo.getName() + " uses classes:");
    System.out.println(uniqueList);*/

		return new Object[]{a1,a2,uniqueList};

	}



	protected List<String> showResult(ClassInformation[] resultData)
	{
		List<String> a1 = new ArrayList<String>();
		for (ClassInformation classInformation : resultData)
		{
			a1.add(classInformation.getName());
			/*System.out.print(classInformation.getName());*/
		}
		return a1;
	}

	protected Workset createWorkset()
	{
		Workset workset;
		workset = new Workset("Sample1");
		ClasspathPartDefinition partDefinition;

		partDefinition = new ClasspathPartDefinition("example-libs/LibraryJTP.jar");
		workset.addClasspathPartDefinition(partDefinition);
		workset.addIgnoreFilter(new StringFilter("java.*"));
		workset.addIgnoreFilter(new StringFilter("javax.*"));
		return workset;
	}





	protected void initializeWorkset(Workset workset)
	{
		WorksetInitializer wsInitializer;
		IProgressMonitor monitor = null;

		if (IS_MONITORING)
		{      
			monitor = new ConsoleMonitor();
		}

		wsInitializer = new WorksetInitializer(workset);

		// Running with no progress monitor (null) is okay as well.
		wsInitializer.initializeWorksetAndWait(monitor); 
	}





	private static String processJarFiles(Object obj) {
		JarEntry entry = (JarEntry)obj;
		String name = entry.getName();
		return name;


		/*long size = entry.getSize();
	       long compressedSize = entry.getCompressedSize();*/

	}




}
