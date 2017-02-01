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
	 
	 JarFile jarFile = new JarFile("example-libs/jgoodies-common-1.8.0.jar");
     Enumeration enumeration = jarFile.entries();
     while (enumeration.hasMoreElements()) {
	    if(processJarFiles(enumeration.nextElement()).endsWith(".class"))
	    {
	    	String cname = processJarFiles(enumeration.nextElement()).replace('/', '.');
	    	String className = cname.replace(".class", "");
	    	arr.add(className);
	    }
     }
     
     System.out.println(arr);
     
     
     
	
    CommandLineArguments commandArgs;
    Sample1 inst;

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
    
    // Create a workset with a defined classpath
    workset = this.createWorkset();
    // Load all elements on the claspath and pre-analyze them (might take a while!)
    this.initializeWorkset(workset);

    for(String i : arr){
    	this.showDependenciesOf(workset, i);
    }
    /*this.showDependenciesOf(workset, CLASS_TO_ANALYZE);*/
    
    
  }
  
  

  protected void showClassesMatching(Workset workset, String namePattern) 
  {
    Pattern pattern = Pattern.compile(namePattern);
    ClassNameFinder processor;
    List<ClassInformation> result = new ArrayList();
    ClassInformation[] classes;

    processor = new ClassNameFinder(pattern);
    workset.processClassInformationObjects(result, processor);
    System.out.println("Scanned " + processor.getResultData() + " classes.");
    System.out.println("Found " + result.size() + " classes for pattern: " + namePattern);
    classes = ClassInformation.collectionToArray(result);    
    this.showResult(classes);    
  }
  
  //
  protected void showDependenciesOf(Workset workset, String className) 
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
    /*System.out.println("\n" + classInfo.getName() + " dependes on " + classes.length + " classes:");
    this.showResult(classes); */   
    System.out.println("\n" + classInfo.getName() + " implements " + directlyImplemntedInterfaces.length + " interfaces:");
    this.showResult(directlyImplemntedInterfaces);   
    List<String> a1 = this.showResult(directlyImplemntedInterfaces);    
    
    // Get classes which are extended by current class/interface
    directlyExtendedInterfaces = classInfo.getDirectlyExtendedInterfaces();
    System.out.println("\n" + classInfo.getName() + " extends " + directlyExtendedInterfaces.length + " classes:");
    this.showResult(directlyExtendedInterfaces);  
    List<String> a2 = this.showResult(directlyExtendedInterfaces);    
    
    
   
    
    
    // Get classes which are used by current class/interface
    allClasses = classInfo.getReferredClassesArray();
    System.out.println("\n" + classInfo.getName() + " uses " + allClasses.length + " classes:");
    List<String> a3 = this.showResult(allClasses); 
    /*List<String> combined = new ArrayList<String>();
    combined.addAll(a1);
    combined.addAll(a2);
    combined.addAll(a3);
    System.out.println("\nCombined array is: " + combined);*/
    ArrayList<String> uniquevalues = new ArrayList<String>(new List(a3).removeAll(a1));  
    
  }
  
  protected void showAllDependenciesOf(Workset workset, String className) 
  {
    ClassInformation classInfo;
    ClassInformation[] classes;
    
    // Lookup the class of interest
    classInfo = workset.getClassInfo(className);

    IAnalyzableElement elementToAnalyze = classInfo;
    DependencyAnalyzer analyzer = new DependencyAnalyzer(elementToAnalyze);
    analyzer.analyze();
    DependencyInfo result = analyzer.getResult();

    classes = result.getAllReferredClasses();    
    System.out.println(classInfo.getName() + " dependes on " + classes.length + " classes:");
    this.showResult(classes);    
  }
  
  protected void showDependantsOf(Workset workset, String className) 
  {
    ClassInformation classInfo;
    ClassInformation[] dependants;
    
    // Lookup the class of interest
    classInfo = workset.getClassInfo(className);
    
    WaitingIElementsProcessingResultHandler searchHandler = new WaitingIElementsProcessingResultHandler();
    dependants = searchHandler.findDependantsOfClass(classInfo, "01", null, true);
    System.out.println(classInfo.getName() + " has " + dependants.length + " classes depending on it:");
    this.showResult(dependants);    
  }
  
  protected List<String> showResult(ClassInformation[] resultData)
  {
	List<String> a1 = new ArrayList();
    for (ClassInformation classInformation : resultData)
    {
      a1.add(classInformation.getName());
      System.out.print(classInformation.getName());
    }
    return a1;
  }

  protected Workset createWorkset()
  {
    Workset workset;
    workset = new Workset("Sample1");
    ClasspathPartDefinition partDefinition;
    
    partDefinition = new ClasspathPartDefinition("example-libs/jgoodies-common-1.8.0.jar");
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
