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

import java.util.jar.JarEntry;
import java.util.jar.JarFile;
import java.io.*;
// ===========================================================================
// IMPORTS
// ===========================================================================
import java.util.*;
import java.util.jar.*;

import org.objectweb.asm.ClassReader;
import org.objectweb.asm.Opcodes;
import org.objectweb.asm.Type;
import org.objectweb.asm.tree.ClassNode;
import org.objectweb.asm.tree.FieldNode;
import org.objectweb.asm.tree.MethodNode;

import org.pf.text.CommandLineArguments;
import org.pf.tools.cda.base.model.ClassContainer;
import org.pf.tools.cda.base.model.ClassInformation;
import org.pf.tools.cda.base.model.ClassPackage;
import org.pf.tools.cda.base.model.GenericClassContainer;
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
import org.pfsw.odem.IContainer;
import org.apache.commons.io.FileUtils;
import org.apache.commons.lang3.ArrayUtils;
import org.json.simple.JSONArray;
import org.json.simple.JSONObject;
import java.io.File;
import java.io.FileWriter;
import java.io.IOException;
import java.nio.charset.Charset;

import org.json.simple.JSONArray;
import org.json.simple.JSONObject;

/**
 * An example for working with CDA without GUI.
 *
 * @author M.Duchrow
 * @version 1.0
 */
public class Sample1 {
	// =========================================================================
	// CONSTANTS
	// =========================================================================
	private static final boolean IS_MONITORING = false;
	private static final String CLASS_TO_ANALYZE = "com.jgoodies.common.collect.ArrayListModel";
	private static final String JAR_TO_ANALYZE = "example-libs/jgoodies-common-1.8.0.jar";

	// =========================================================================
	// INSTANCE VARIABLES
	// =========================================================================

	// =========================================================================
	// CLASS METHODS
	// =========================================================================
	public static void main(String[] args) throws InterruptedException, IOException {

		CommandLineArguments commandArgs;
		commandArgs = new CommandLineArguments(args);
		String dir = commandArgs.getArgumentValue("-d");
		Map<String, HashMap<String, ArrayList<String>>> arr = new HashMap<String, HashMap<String, ArrayList<String>>>();

		JarFile jarFile = new JarFile(dir);
		Enumeration enumeration = jarFile.entries();
		while (enumeration.hasMoreElements()) {
			ArrayList<String> listOfMethods = new ArrayList<String>();
			ArrayList<String> listOfFields = new ArrayList<String>();
			HashMap<String, ArrayList<String>> tmparr = new HashMap<String, ArrayList<String>>();
			JarEntry entry = (JarEntry) enumeration.nextElement();
			String tmpName = entry.getName();

			/*
			 * long size = entry.getSize(); long compressedSize =
			 * entry.getCompressedSize();
			 */

			if (tmpName.endsWith(".class")) {
				String cname = tmpName.replace("/", ".");
				String className = cname.replace(".class", "");

				ClassNode classNode = new ClassNode();

				InputStream classFileInputStream = jarFile.getInputStream(entry);
				try {
					ClassReader classReader = new ClassReader(classFileInputStream);
					classReader.accept(classNode, 0);
				} finally {
					classFileInputStream.close();
				}
				// The method signatures (e.g. - "public static void
				// main(String[]) throws Exception")
				@SuppressWarnings("unchecked")
				List<MethodNode> methodNodes = classNode.methods;

				for (MethodNode methodNode : methodNodes) {
					String methodDescription = describeMethod(methodNode);
					listOfMethods.add(methodDescription);
				}

				List<FieldNode> fieldNodes = classNode.fields;

				for (FieldNode fieldNode : fieldNodes) {
					String fieldDescription = describeField(fieldNode);
					listOfFields.add(fieldDescription);
				}

				tmparr.put("list1", listOfFields);
				tmparr.put("list2", listOfMethods);
				arr.put(className, tmparr);

			}
		}

		Sample1 inst;
		List<String> implementArray = new ArrayList<String>();
		List<String> extendtArray = new ArrayList<String>();
		List<String> useArray = new ArrayList<String>();

		inst = new Sample1();

		inst.run(commandArgs, arr, dir);
		System.err.flush();
		System.out.flush();
		SysUtil.current().exit(0, 100);
	} // main()

	// =========================================================================
	// CONSTRUCTORS
	// =========================================================================
	public Sample1() {
		super();
	}

	// =========================================================================
	// PROTECTED INSTANCE METHODS
	// =========================================================================
	/*
	 * protected void run(CommandLineArguments args) { Workset workset; String
	 * sample;
	 * 
	 * // Create a workset with a defined classpath workset =
	 * this.createWorkset(); // Load all elements on the claspath and
	 * pre-analyze them (might take a while!) this.initializeWorkset(workset);
	 * 
	 * sample = args.getArgumentValue("-sample");
	 * 
	 * if ("1".equals(sample)) { this.showClassesMatching(workset, "F.*r$"); }
	 * else if ("2".equals(sample)) {
	 * 
	 * this.showDependenciesOf(workset, CLASS_TO_ANALYZE); } else if
	 * ("3".equals(sample)) { this.showAllDependenciesOf(workset,
	 * CLASS_TO_ANALYZE); } else if ("4".equals(sample)) {
	 * this.showDependantsOf(workset, CLASS_TO_ANALYZE); } }
	 */

	protected void run(CommandLineArguments commandArgs, Map<String, HashMap<String, ArrayList<String>>> arr,
			String dir) throws IOException {
		Workset workset;
		String sample;
		Set<String> packageNameSet = new HashSet<String>();

		JSONObject obj = new JSONObject();
		obj.put("class", "go.GraphLinksModel");
		obj.put("nodeKeyProperty", "id");

		JSONArray nodeArray = new JSONArray();
		JSONArray linkArray = new JSONArray();

		// Create a workset with a defined classpath
		workset = this.createWorkset(dir);
		// Load all elements on the claspath and pre-analyze them (might take a
		// while!)
		this.initializeWorkset(workset);

		
		List<String> listAllPackages = new ArrayList<String>();
		listAllPackages = this.listAllPackages(workset);
		System.out.println(listAllPackages);
		for(String packageName : listAllPackages){
			
		}
		
		String htmlString1 = new String();
		for (Map.Entry<String, HashMap<String, ArrayList<String>>> entry : arr.entrySet()) {
			String i = entry.getKey();
			

			/* HashMap<String,ArrayList<String>> sax = entry.getValue(); */
			HashMap<String, ArrayList<String>> listOfFieldsAndMethods = entry.getValue();

			ArrayList<String> listOfMethodsJson = listOfFieldsAndMethods.get("list2");
			ArrayList<String> listOfFieldsJson = listOfFieldsAndMethods.get("list1");


			String tmpString = "<tr><td>" + i + "</td><td>";
			htmlString1 = htmlString1 + tmpString;
			
			JSONObject obj1 = new JSONObject();
			obj1.put("category", "UndesiredEvent");
			obj1.put("id", i);
			obj1.put("text", i);
			obj1.put("color", "lightyellow");

			JSONObject objlistOfMethodsJson = new JSONObject();
			List<JSONObject> listOfMethodsTextArray = new ArrayList<>();
			for (String ilistOfMethodsJson : listOfMethodsJson) {
				JSONObject iobjlistOfMethodsJson = new JSONObject();
				iobjlistOfMethodsJson.put("text", ilistOfMethodsJson);
				listOfMethodsTextArray.add(iobjlistOfMethodsJson);
			}
			obj1.put("list2", listOfMethodsTextArray);

			JSONObject objlistOfFieldsJson = new JSONObject();
			List<JSONObject> listOfFieldsTextArray = new ArrayList<>();
			for (String ilistOfFieldsJson : listOfFieldsJson) {
				JSONObject iobjlistOfFieldsJson = new JSONObject();
				iobjlistOfFieldsJson.put("text", ilistOfFieldsJson);
				listOfFieldsTextArray.add(iobjlistOfFieldsJson);
			}
			obj1.put("list1", listOfFieldsTextArray);

			if (!nodeArray.contains(obj1)) {
				nodeArray.add(obj1);
			}

			List<String> list1 = new ArrayList<String>();
			List<String> list2 = new ArrayList<String>();
			List<String> list3 = new ArrayList<String>();
			Object[] listOfArrays = this.showDependenciesOfClass(workset, i);
			
			
			
			list1 = (List<String>) listOfArrays[0];
			list2 = (List<String>) listOfArrays[1];
			list3 = (List<String>) listOfArrays[2];

			if (list1.isEmpty() == false) {
				for (String j1 : list1) {
					String tmpString1 = j1 + "<br>";
					htmlString1 = htmlString1 + tmpString1;
					JSONObject obj2 = new JSONObject();
					obj2.put("from", i);
					obj2.put("color", "#2F4F4F");
					obj2.put("thick", 1.5);
					obj2.put("category", "Realization");
					obj2.put("to", j1);
					linkArray.add(obj2);

					/*
					 * JSONObject obj1_1 = new JSONObject();
					 * obj1_1.put("category","UndesiredEvent");
					 * obj1_1.put("id",j1); obj1_1.put("text",j1);
					 * obj1_1.put("color", "lightyellow");
					 * if(!nodeArray.contains(obj1_1)){ nodeArray.add(obj1_1); }
					 */

				}
			}

			htmlString1 = htmlString1 + "</td><td>";
			if (list2.isEmpty() == false) {
				for (String j : list2) {
					String tmpString2 = j + "<br>";
					htmlString1 = htmlString1 + tmpString2;

					JSONObject obj2 = new JSONObject();
					obj2.put("from", i);
					obj2.put("color", "#2F4F4F");
					obj2.put("thick", 1.5);
					obj2.put("category", "Generalization");
					obj2.put("to", j);
					linkArray.add(obj2);

					/*
					 * JSONObject obj1_1 = new JSONObject();
					 * obj1_1.put("category","UndesiredEvent");
					 * obj1_1.put("id",j); obj1_1.put("text",j);
					 * obj1_1.put("color", "lightyellow");
					 * if(!nodeArray.contains(obj1_1)){ nodeArray.add(obj1_1); }
					 */
				}
			}

			htmlString1 = htmlString1 + "</td><td>";
			if (list3.isEmpty() == false) {
				for (String j : list3) {
					String tmpString3 = j + "<br>";
					htmlString1 = htmlString1 + tmpString3;
					JSONObject obj2 = new JSONObject();
					obj2.put("from", i);
					obj2.put("color", "#2F4F4F");
					obj2.put("thick", 1.5);
					obj2.put("category", "DirectedAssociation");
					obj2.put("to", j);
					linkArray.add(obj2);

					/*
					 * JSONObject obj1_1 = new JSONObject();
					 * obj1_1.put("category","UndesiredEvent");
					 * obj1_1.put("id",j); obj1_1.put("text",j);
					 * obj1_1.put("color", "lightyellow");
					 * if(!nodeArray.contains(obj1_1)){ nodeArray.add(obj1_1); }
					 */
				}
			}

			htmlString1 = htmlString1 + "</td></tr>";
		}

		obj.put("nodeDataArray", nodeArray);
		obj.put("linkDataArray", linkArray);

		try (FileWriter file = new FileWriter("views/json/test.json")) {

			file.write(obj.toString());
			file.flush();

		} catch (IOException e) {
			e.printStackTrace();
		}
		
		try (FileWriter file = new FileWriter("views/json/classview.json")) {

			file.write(obj.toString());
			file.flush();

		} catch (IOException e) {
			e.printStackTrace();
		}

		
		
		this.createHtmlFile(htmlString1);

	}
	
	// List of packages contained in uploaded file
	protected List<String> listAllPackages(Workset workset) {
		
		List<String> list1 = new ArrayList<String>();
		GenericClassContainer[] listOfClassContainers = workset.getClassContainers();
		
		JSONObject obj = new JSONObject();
		obj.put("class", "go.GraphLinksModel");
		obj.put("nodeKeyProperty", "id");
		JSONArray nodeArray = new JSONArray();
		JSONArray linkArray = new JSONArray();
		
		for(GenericClassContainer classContainer: listOfClassContainers){
			ClassPackage[] listOfPackages = classContainer.getPackages();
			for(ClassPackage classPackage : listOfPackages){
				String classPackageName = classPackage.getName();
				
				JSONObject obj1 = new JSONObject();
				obj1.put("category", "UndesiredEvent");
				obj1.put("id", classPackageName);
				obj1.put("text", classPackageName);
				obj1.put("color", "lightyellow");
				nodeArray.add(obj1);
				
				
				ClassPackage[] listOfDirectReferredPackages = classPackage.getDirectReferredPackages();
				for(ClassPackage j : listOfDirectReferredPackages){
					JSONObject obj2 = new JSONObject();
					obj2.put("from", classPackageName);
					obj2.put("color", "#2F4F4F");
					obj2.put("thick", 1.5);
					obj2.put("category", "DirectedAssociation");
					obj2.put("to", j.getName());
					linkArray.add(obj2);
				}
				
			}
		}
		
		obj.put("nodeDataArray", nodeArray);
		obj.put("linkDataArray", linkArray);
		System.out.print(obj);
		
		try (FileWriter file = new FileWriter("views/json/packageview.json")) {

			file.write(obj.toString());
			file.flush();

		} catch (IOException e) {
			e.printStackTrace();
		}
		
		return list1;
	}
	
	protected void showDependenciesOfPackage(Workset workset) {
	}

	// -----------------
	protected Object[] showDependenciesOfClass(Workset workset, String className) {
		ClassInformation classInfo;
		ClassInformation[] allClasses;
		ClassInformation[] directlyUseClasses;
		ClassInformation[] directlyImplemntedInterfaces;
		ClassInformation[] directlyExtendedInterfaces;
		ClassInformation[] notUniqClasses;
		

		// Lookup the class of interest 
		classInfo = workset.getClassInfo(className);
		
		
		

		// Get interfaces which are implemented by current class/interface
		// (Realization)
		directlyImplemntedInterfaces = classInfo.getDirectlyImplementedInterfaces();
		List<String> a1 = this.showResult(directlyImplemntedInterfaces);


		// Get classes which are extended by current class/interface
		// (Generalization)
		directlyExtendedInterfaces = classInfo.getDirectlyExtendedInterfaces();
		List<String> a2 = this.showResult(directlyExtendedInterfaces);
	

		// Combine two arrays
		List<String> a12 = new ArrayList<String>(a1);
		a12.addAll(a2);

		// Get classes which are used by current class/interface (Directed
		// Association)
		allClasses = classInfo.getReferredClassesArray();
		List<String> a3 = this.showResult(allClasses);

		// Get unique values
		List<String> duplicateList = new ArrayList<String>();
		List<String> uniqueList = new ArrayList<String>();
		for (String item : a3) {
			if (a12.contains(item)) {
				duplicateList.add(item);
			} else {
				uniqueList.add(item);
			}
		}
		

		return new Object[] { a1, a2, uniqueList };

	}

	protected List<String> showResult(ClassInformation[] resultData) {
		List<String> a1 = new ArrayList<String>();
		for (ClassInformation classInformation : resultData) {
			a1.add(classInformation.getName());
		}
		return a1;
	}

	protected Workset createWorkset(String dir) {
		Workset workset;
		workset = new Workset("Sample1");
		ClasspathPartDefinition partDefinition;

		partDefinition = new ClasspathPartDefinition(dir);
		workset.addClasspathPartDefinition(partDefinition);
		workset.addIgnoreFilter(new StringFilter("java.*"));
		workset.addIgnoreFilter(new StringFilter("javax.*"));
		workset.addIgnoreFilter(new StringFilter("com.sun.awt.*"));
		return workset;
	}

	protected void initializeWorkset(Workset workset) {
		WorksetInitializer wsInitializer;
		IProgressMonitor monitor = null;

		if (IS_MONITORING) {
			monitor = new ConsoleMonitor();
		}

		wsInitializer = new WorksetInitializer(workset);

		// Running with no progress monitor (null) is okay as well.
		wsInitializer.initializeWorksetAndWait(monitor);
	}

	// Create report.html file
	protected void createHtmlFile(String class1) throws IOException {
		File htmlTemplateFile = new File("views/output/template.html");
		String htmlString = FileUtils.readFileToString(htmlTemplateFile, Charset.forName("UTF-8"));
		String contents = class1;
		htmlString = htmlString.replace("$contents", contents);
		File newHtmlFile = new File("views/output/report.html");
		FileUtils.writeStringToFile(newHtmlFile, htmlString, Charset.forName("UTF-8"));

	}

	/*
	 * public static String describeClass(ClassNode classNode) { StringBuilder
	 * classDescription = new StringBuilder();
	 * 
	 * Type classType = Type.getObjectType(classNode.name);
	 * 
	 * 
	 * 
	 * // The class signature (e.g. - "public class Foo") if ((classNode.access
	 * & Opcodes.ACC_PUBLIC) != 0) { classDescription.append("public "); }
	 * 
	 * if ((classNode.access & Opcodes.ACC_PRIVATE) != 0) {
	 * classDescription.append("private "); }
	 * 
	 * if ((classNode.access & Opcodes.ACC_PROTECTED) != 0) {
	 * classDescription.append("protected "); }
	 * 
	 * if ((classNode.access & Opcodes.ACC_ABSTRACT) != 0) {
	 * classDescription.append("abstract "); }
	 * 
	 * if ((classNode.access & Opcodes.ACC_INTERFACE) != 0) {
	 * classDescription.append("interface "); } else {
	 * classDescription.append("class "); }
	 * 
	 * classDescription.append(classType.getClassName()).append("\n");
	 * classDescription.append("{\n");
	 * 
	 * 
	 * 
	 * // The method signatures (e.g. -
	 * "public static void main(String[]) throws Exception")
	 * 
	 * @SuppressWarnings("unchecked") List<MethodNode> methodNodes =
	 * classNode.methods;
	 * 
	 * for (MethodNode methodNode : methodNodes) { String methodDescription =
	 * describeMethod(methodNode);
	 * classDescription.append("\t").append(methodDescription).append("\n"); }
	 * 
	 * 
	 * 
	 * classDescription.append("}\n");
	 * 
	 * return classDescription.toString(); }
	 */

	public static String describeMethod(MethodNode methodNode) {
		StringBuilder methodDescription = new StringBuilder();

		Type returnType = Type.getReturnType(methodNode.desc);
		Type[] argumentTypes = Type.getArgumentTypes(methodNode.desc);

		/*
		 * @SuppressWarnings("unchecked") List<String> thrownInternalClassNames
		 * = methodNode.exceptions;
		 */

		if ((methodNode.access & Opcodes.ACC_PUBLIC) != 0) {
			methodDescription.append("public ");
		}

		if ((methodNode.access & Opcodes.ACC_PRIVATE) != 0) {
			methodDescription.append("private ");
		}

		if ((methodNode.access & Opcodes.ACC_PROTECTED) != 0) {
			methodDescription.append("protected ");
		}

		if ((methodNode.access & Opcodes.ACC_STATIC) != 0) {
			methodDescription.append("static ");
		}

		if ((methodNode.access & Opcodes.ACC_ABSTRACT) != 0) {
			methodDescription.append("abstract ");
		}

		if ((methodNode.access & Opcodes.ACC_SYNCHRONIZED) != 0) {
			methodDescription.append("synchronized ");
		}

		methodDescription.append(returnType.getClassName());
		methodDescription.append(" ");
		methodDescription.append(methodNode.name);

		methodDescription.append("(");
		for (int i = 0; i < argumentTypes.length; i++) {
			Type argumentType = argumentTypes[i];
			if (i > 0) {
				methodDescription.append(", ");
			}
			methodDescription.append(argumentType.getClassName());
		}
		methodDescription.append(")");

		/*
		 * if (!thrownInternalClassNames.isEmpty()) {
		 * methodDescription.append(" throws "); int i = 0; for (String
		 * thrownInternalClassName : thrownInternalClassNames) { if (i > 0) {
		 * methodDescription.append(", "); }
		 * methodDescription.append(Type.getObjectType(thrownInternalClassName).
		 * getClassName()); i++; } }
		 */

		return methodDescription.toString();
	}

	public static String describeField(FieldNode fieldNode) {
		StringBuilder fieldDescription = new StringBuilder();

		Type returnType = Type.getType(fieldNode.desc);

		/*
		 * @SuppressWarnings("unchecked") List<String> thrownInternalClassNames
		 * = fieldNode.
		 */

		if ((fieldNode.access & Opcodes.ACC_PUBLIC) != 0) {
			fieldDescription.append("public ");
		}

		if ((fieldNode.access & Opcodes.ACC_PRIVATE) != 0) {
			fieldDescription.append("private ");
		}

		if ((fieldNode.access & Opcodes.ACC_PROTECTED) != 0) {
			fieldDescription.append("protected ");
		}

		if ((fieldNode.access & Opcodes.ACC_STATIC) != 0) {
			fieldDescription.append("static ");
		}

		if ((fieldNode.access & Opcodes.ACC_ABSTRACT) != 0) {
			fieldDescription.append("abstract ");
		}

		if ((fieldNode.access & Opcodes.ACC_SYNCHRONIZED) != 0) {
			fieldDescription.append("synchronized ");
		}

		fieldDescription.append(returnType.getClassName());
		fieldDescription.append(" ");
		fieldDescription.append(fieldNode.name);

		/*
		 * fieldDescription.append("("); for (int i = 0; i <
		 * argumentTypes.length; i++) { Type argumentType = argumentTypes[i]; if
		 * (i > 0) { fieldDescription.append(", "); }
		 * fieldDescription.append(argumentType.getClassName()); }
		 * fieldDescription.append(")");
		 */

		/*
		 * if (!thrownInternalClassNames.isEmpty()) {
		 * fieldDescription.append(" throws "); int i = 0; for (String
		 * thrownInternalClassName : thrownInternalClassNames) { if (i > 0) {
		 * fieldDescription.append(", "); }
		 * fieldDescription.append(Type.getObjectType(thrownInternalClassName).
		 * getClassName()); i++; } }
		 */

		return fieldDescription.toString();
	}

}
